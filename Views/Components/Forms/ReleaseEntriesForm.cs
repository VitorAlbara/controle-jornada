using controle_jornada.DTOs;
using controle_jornada.Helpers.AppData;
using controle_jornada.Models;
using controle_jornada.Repositories;
using controle_jornada.Services;
using System.Diagnostics;
using System.Text.Json;

namespace controle_jornada.Views.Components.Forms
{
    public partial class ReleaseEntriesForm : Form
    {
        public bool launchTasks;
        private readonly RedmineServ _redmineService = new RedmineServ();
        private readonly EntradaLocalRepo _localEntriesRepo = new EntradaLocalRepo();
        private readonly ProjetoRepo _projectRepo = new ProjetoRepo();
        private List<Atividade> _activities = new List<Atividade>();
        private List<IndicativoProjeto> _projectIndicators = IndicativoProjeto.PegarIndicativosPadroes();
        private List<EntradaLocal> _localEntries = new List<EntradaLocal>();
        private List<Projeto> _projects = new List<Projeto>();
        private DateOnly _currentDate;

        public ReleaseEntriesForm(DateOnly currentDate)
        {
            InitializeComponent();
            _currentDate = currentDate;
            gridEntries.EditMode = DataGridViewEditMode.EditOnEnter;
            launchTasks = false;
        }

        public async Task LoadDataAsync()
        {
            try
            {
                _activities = await _redmineService.PegarAtividades();
                _localEntries = await _localEntriesRepo.PegarTodosPorData(_currentDate);
                _projects = await _projectRepo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopulateGrid()
        {
            var user = DadosUsuario.CarregarDadosUsuario();
            gridEntries.Rows.Clear();

            foreach (var entry in _localEntries)
            {
                TimeSpan duration = TimeSpan.FromSeconds(entry.Duracao);

                if (duration < TimeSpan.FromMinutes(1))
                    continue;

                var rowIndex = gridEntries.Rows.Add();
                var row = gridEntries.Rows[rowIndex];

                if (row.Cells["colProject"] is DataGridViewComboBoxCell projectCell)
                {
                    projectCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    projectCell.DataSource = _projects.ToList();
                    projectCell.DisplayMember = "Name";
                    projectCell.ValueMember = "Id";
                }

                if (row.Cells["colActivity"] is DataGridViewComboBoxCell activityCell)
                {
                    activityCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    activityCell.DataSource = _activities.ToList();
                    activityCell.DisplayMember = "Name";
                    activityCell.ValueMember = "Id";
                }

                if (row.Cells["colProjectInd"] is DataGridViewComboBoxCell projectIndicatorCell)
                {
                    projectIndicatorCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    projectIndicatorCell.DataSource = _projectIndicators.ToList();
                    projectIndicatorCell.DisplayMember = "Name";
                    projectIndicatorCell.ValueMember = "Value";
                }

                if (row.Cells["colExecPlace"] is DataGridViewComboBoxCell executionPlaceCell)
                {
                    executionPlaceCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    executionPlaceCell.DataSource = new[] { "Fora da Cidade", "Dentro da Cidade", "Interno" };
                }

                if (row.Cells["colOvertime"] is DataGridViewComboBoxCell overtimeCell)
                {
                    overtimeCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    overtimeCell.DataSource = new[] { "Sim", "Não" };
                }

                row.Cells["colDate"].Value = entry.DataEntrada.ToString("dd/MM/yyyy");
                row.Cells["colDuration"].Value = duration.ToString(@"hh\:mm");
                row.Cells["colTaskTitle"].Value = entry.Tarefa.Titulo;
                row.Cells["colId"].Value = entry.Id;

                if (entry.TarefaId < 0)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                        cell.ReadOnly = true;

                    row.Cells["colTaskNum"].Value = "Estudo";

                    if (row.Cells["colOk"] is DataGridViewCheckBoxCell checkBoxCell)
                        checkBoxCell.Value = true;
                }
                else if (entry.TarefaId > 0)
                {
                    row.Cells["colTaskNum"].Value = entry.TarefaId;

                    if (row.Cells["colProject"] is DataGridViewComboBoxCell)
                        row.Cells["colProject"].Value = entry.Tarefa.Projeto;
                }
                else
                {
                    row.Cells["colTaskNum"].Value = "Customizada";
                    row.Cells["colComment"].Value = entry.TarefaId;
                    row.Cells["colComment"].ReadOnly = true;

                    if (row.Cells["colProject"] is DataGridViewComboBoxCell)
                        row.Cells["colProject"].Value = user.ProjetoId;
                }
            }

            UpdateLabelQtd();
        }

        private void UpdateLabelQtd()
        {
            int totalRows = gridEntries.Rows.Count;
            int checkedRows = gridEntries.Rows
                .Cast<DataGridViewRow>()
                .Count(r => (bool?)r.Cells["colOk"].Value == true);

            txtQtd.Text = $"{checkedRows:00}/{totalRows:00}";
        }

        private void ValidateRow(DataGridViewRow row)
        {
            if (row == null)
                return;

            if (row.Cells["colTaskNum"].Value?.ToString() == "Estudo")
                return;

            bool isProjectSelected = row.Cells["colProject"] is DataGridViewComboBoxCell projectCell
                                    && projectCell.Value != null;

            bool isActivitySelected = row.Cells["colActivity"] is DataGridViewComboBoxCell activityCell
                                    && activityCell.Value != null;

            bool isProjectIndicatorSelected = row.Cells["colProjectInd"] is DataGridViewComboBoxCell projectIndicatorCell
                                            && projectIndicatorCell.Value != null;

            if (row.Cells["colOk"] is DataGridViewCheckBoxCell checkBoxCell)
                checkBoxCell.Value = isProjectSelected && isActivitySelected && isProjectIndicatorSelected;

            UpdateLabelQtd();
        }

        public async System.Threading.Tasks.Task LaunchTasks()
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            foreach (DataGridViewRow row in gridEntries.Rows)
            {
                if ((bool?)row.Cells["colOk"].Value != true)
                    continue;

                int taskNum = int.Parse(row.Cells["colTaskNum"].Value?.ToString());

                if (taskNum > 0)
                    await ReleaseHoursForRowAsync(row, user.ChaveApi);
                else
                {
                    string durationHhMm = row.Cells["colDuration"].Value?.ToString() ?? "00:00";
                    string durationHhMmSs = $"{durationHhMm}:00";

                    var entriesRepo = new EntradaRepo();

                    await entriesRepo.AdicionarOuAtualizar(new Entrada
                    {
                        Id = await entriesRepo.PegarProxIdNegativo(),
                        TarefaId = -1,
                        TarefaUsuarioId = user.Id,
                        DataEntrada = DateOnly.FromDateTime(DateTime.Now),
                        Duracao = ConvertHhMmSsToSeconds(durationHhMmSs)
                    });

                    OpenGoogleForm();
                }
            }

            await RemoveLaunchedLocalEntriesAsync();
        }

        private int ConvertHhMmSsToSeconds(string hhmmss)
        {
            if (TimeSpan.TryParse(hhmmss, out var ts))
            {
                return (int)ts.TotalSeconds;
            }
            return 0;
        }

        private void OpenGoogleForm()
        {
            string formUrl = "https://docs.google.com/forms/d/e/1FAIpQLScR4LfXz2UQoslqUukuLfaF27b3GCdfs-roW7K-dTcGBceG8A/viewform";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = formUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o formulário Registro de Treinamento/Curso/Capacitação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ReleaseHoursForRowAsync(DataGridViewRow row, string apiKey)
        {
            string taskNum = row.Cells["colTaskNum"].Value?.ToString();
            string dateText = row.Cells["colDate"].Value?.ToString();
            string durationHhMm = row.Cells["colDuration"].Value?.ToString();
            string projectIdStr = row.Cells["colProject"].Value?.ToString();
            string activityIdStr = row.Cells["colActivity"].Value?.ToString();
            string comment = row.Cells["colComment"].Value?.ToString() ?? "";
            string projInd = row.Cells["colProjectInd"].Value?.ToString();
            string execPlace = row.Cells["colExecPlace"].Value?.ToString();
            string overtime = row.Cells["colOvertime"].Value?.ToString();

            DateTime date = ParseDate(dateText);

            bool isIssue = int.TryParse(taskNum, out int issueId);

            var existingEntry = await GetExistingTimeEntryAsync(
                apiKey,
                isIssue,
                isIssue ? issueId : (int?)null,
                isIssue ? null : (int?)Convert.ToInt32(projectIdStr),
                isIssue ? null : comment,
                date
            );

            if (existingEntry != null)
            {
                existingEntry.Horas = SumDoubleAndHhMm(existingEntry.Horas, durationHhMm);

                if (!isIssue)
                    existingEntry.Comentarios = comment;

                existingEntry.AtividadeId = Convert.ToInt32(activityIdStr);

                existingEntry.CamposCustomizados = new List<CampoCustomizadoDto>
                {
                    new CampoCustomizadoDto { Id = 143, Valor = projInd },
                    new CampoCustomizadoDto { Id = 21,  Valor = execPlace },
                    new CampoCustomizadoDto { Id = 117, Valor = overtime },
                };

                await UpdateTimeEntryAsync(apiKey, existingEntry);
            }
            else
            {
                double hoursAsDouble = ConvertHhMmToDouble(durationHhMm);

                var newEntry = new TempoEntradaDto
                {
                    IssueId = isIssue ? issueId : (int?)null,
                    ProjetoId = isIssue ? null : (int?)Convert.ToInt32(projectIdStr),
                    GastoEm = date.ToString("yyyy-MM-dd"),
                    Horas = hoursAsDouble,
                    AtividadeId = Convert.ToInt32(activityIdStr),
                    Comentarios = isIssue ? "" : comment,
                    CamposCustomizados = new List<CampoCustomizadoDto>
                    {
                        new CampoCustomizadoDto { Id = 143, Valor = projInd },
                        new CampoCustomizadoDto { Id = 21,  Valor = execPlace },
                        new CampoCustomizadoDto { Id = 117, Valor = overtime },
                    }
                };

                await CreateTimeEntryAsync(apiKey, newEntry);
            }
        }

        private async Task<TempoEntradaDto> GetExistingTimeEntryAsync(
            string apiKey,
            bool isIssue,
            int? issueId,
            int? projectId,
            string customTaskId,
            DateTime date
        )
        {
            var user = DadosUsuario.CarregarDadosUsuario();
            int userId = user.Id;

            string baseUrl = "https://redmine.questor.com.br/time_entries.json?limit=100";
            string dateParam = date.ToString("yyyy-MM-dd");
            baseUrl += $"&user_id={userId}&spent_on={dateParam}";

            if (isIssue && issueId.HasValue)
            {
                baseUrl += $"&issue_id={issueId.Value}";
            }
            else if (!isIssue && projectId.HasValue)
            {
                baseUrl += $"&project_id={projectId.Value}";
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Redmine-API-Key", apiKey);

                var response = await client.GetAsync(baseUrl);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TempoEntradaResultDto>(json);

                if (result.TempoEntradas == null || !result.TempoEntradas.Any())
                    return null;

                if (isIssue)
                {
                    return result.TempoEntradas.FirstOrDefault();
                }
                else
                {
                    return result.TempoEntradas
                        .FirstOrDefault(te => te.Comentarios?.Equals(customTaskId, StringComparison.OrdinalIgnoreCase) == true);
                }
            }
        }

        private async System.Threading.Tasks.Task UpdateTimeEntryAsync(string apiKey, TempoEntradaDto dto)
        {
            string url = $"https://redmine.questor.com.br/time_entries/{dto.Id}.json";

            var body = new
            {
                time_entry = new
                {
                    hours = dto.Horas,
                    comments = dto.Comentarios,
                    activity_id = dto.AtividadeId,
                    custom_fields = dto.CamposCustomizados
                        .Select(cf => new { id = cf.Id, value = cf.Valor })
                        .ToArray()
                }
            };

            var jsonBody = JsonSerializer.Serialize(body);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Redmine-API-Key", apiKey);

                var request = new HttpRequestMessage(HttpMethod.Put, url)
                {
                    Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
        }

        private async System.Threading.Tasks.Task CreateTimeEntryAsync(string apiKey, TempoEntradaDto dto)
        {
            string url = "https://redmine.questor.com.br/time_entries.json";

            var body = new
            {
                time_entry = new
                {
                    project_id = dto.ProjetoId,
                    issue_id = dto.IssueId,
                    spent_on = dto.GastoEm,
                    hours = dto.Horas,
                    activity_id = dto.AtividadeId,
                    comments = dto.Comentarios,
                    custom_fields = dto.CamposCustomizados
                        .Select(cf => new { id = cf.Id, value = cf.Valor })
                        .ToArray()
                }
            };

            var jsonBody = JsonSerializer.Serialize(body);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Redmine-API-Key", apiKey);

                var response = await client.PostAsync(
                    url,
                    new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json")
                );
                response.EnsureSuccessStatusCode();
            }
        }

        private double SumDoubleAndHhMm(double existingHours, string hhmm)
        {
            int existingSeconds = (int)(existingHours * 3600);
            int newSeconds = ConvertHhMmToSeconds(hhmm);

            int totalSeconds = existingSeconds + newSeconds;
            return totalSeconds / 3600.0;
        }


        private double ConvertHhMmToDouble(string hhmm)
        {
            int seconds = ConvertHhMmToSeconds(hhmm);
            return seconds / 3600.0;
        }

        private int ConvertHhMmToSeconds(string hhmm)
        {
            if (TimeSpan.TryParse(hhmm, out var ts))
                return (int)ts.TotalSeconds;
            return 0;
        }

        private string ConvertSecondsToHhMm(int totalSeconds)
        {
            var ts = TimeSpan.FromSeconds(totalSeconds);
            return ts.ToString(@"hh\:mm");
        }

        private DateTime ParseDate(string ddMMyyyy)
        {
            DateTime.TryParse(ddMMyyyy, out var dt);
            return dt;
        }

        private async System.Threading.Tasks.Task RemoveLaunchedLocalEntriesAsync()
        {
            foreach (DataGridViewRow row in gridEntries.Rows)
            {
                if ((bool?)row.Cells["colOk"].Value != true)
                    continue;

                if (row.Cells["colId"].Value == null || !int.TryParse(row.Cells["colId"].Value.ToString(), out int localEntrieId))
                    continue;

                await _localEntriesRepo.Deletar((int)row.Cells["colId"].Value);
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            bool anyRowReady = gridEntries.Rows
             .Cast<DataGridViewRow>()
             .Any(row => (bool?)row.Cells["colOk"].Value == true);

            if (!anyRowReady)
            {
                MessageBox.Show(
                    "É necessário ao menos um registro revisado para prosseguir.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            launchTasks = true;

            this.Close();
        }

        private void gridEntries_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                ValidateRow(gridEntries.Rows[e.RowIndex]);
            }
        }

        private void gridEntries_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!gridEntries.IsCurrentCellDirty)
                return;

            gridEntries.CommitEdit(DataGridViewDataErrorContexts.Commit);

            int rowIndex = gridEntries.CurrentCell?.RowIndex ?? -1;
            if (rowIndex < 0)
                return;

            ValidateRow(gridEntries.Rows[rowIndex]);
        }

        private void gridEntries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = gridEntries[e.ColumnIndex, e.RowIndex];
                if (cell is DataGridViewComboBoxCell)
                {
                    gridEntries.BeginEdit(true);
                }
            }
        }
    }
}
