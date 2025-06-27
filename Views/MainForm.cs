using controle_jornada.Enums;
using controle_jornada.Helpers.AppData;
using controle_jornada.Helpers.DataSync;
using controle_jornada.Models;
using controle_jornada.Repositories;
using controle_jornada.Services;
using controle_jornada.Views.Components.Cards;
using controle_jornada.Views.Components.Forms;

namespace controle_jornada.Views
{
    public partial class MainForm : Form
    {
        public Usuario Usuario { get; set; }

        private readonly TarefaRepo _tarefaRepo = new TarefaRepo();
        private readonly VersaoRepo _versaoRepo = new VersaoRepo();
        private ICollection<Tarefa> _tarefas;
        private DateOnly dataAtual;

        public MainForm()
        {
            InitializeComponent();

            txtAppVersion.Text = $"Versão: {Application.ProductVersion.Split('+')[0]}";
            dataAtual = DateOnly.FromDateTime(DateTime.Today);
            AtualizarLabelData();

            this.Load += MainForm_Load;
        }

        private void AtualizarLabelData()
        {
            lblDate.Text = dataAtual.ToString("dd/MM/yyyy");
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            MostrarCarregamento(true);

            try
            {
                Usuario = DadosUsuario.CarregarDadosUsuario();
                if (Usuario == null)
                    throw new Exception("Usuário não encontrado.");

                txtName.Text = Usuario.Nome;

                AtualizarLabelData();
                await InicializarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarCarregamento(false);
            }
        }

        private void MostrarCarregamento(bool estaCarregando)
        {
            pnlLoading.Visible = estaCarregando;
            pnlLoading.BringToFront();
            btnCalendar.Enabled = !estaCarregando;
            btnNext.Enabled = !estaCarregando;
            btnPrev.Enabled = !estaCarregando;
            txtTaskSearch.Enabled = !estaCarregando;
            btnAddTask.Enabled = !estaCarregando;
            btnRefreshTasks.Enabled = !estaCarregando;
            btnReleaseTasks.Enabled = !estaCarregando;

            if (estaCarregando)
            {
                txtWorkTime.Text = "";
                txtStudyTime.Text = "";
                txtTotalTime.Text = "";
                txtReleasedTime.Text = "";
                txtBeggingTime.Text = "";
            }
        }

        private async Task InicializarDados()
        {
            try
            {
                await TarefaSync.Run(dataAtual);
                await CarregarTarefas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ControlarTotalizadores()
        {
            EntradaRepo entradaRepo = new EntradaRepo();
            EntradaLocalRepo entradaLocalRepo = new EntradaLocalRepo();

            string tempoLancado = TimeSpan.FromSeconds(await entradaRepo.PegarTempoLancado(dataAtual)).ToString(@"hh\:mm\:ss");
            string tempoPendente = TimeSpan.FromSeconds(await entradaLocalRepo.PegarTempoLancado(dataAtual)).ToString(@"hh\:mm\:ss");
            string duracaoTotal = TimeSpan.FromSeconds(await entradaRepo.PegarTotalGastoDia(dataAtual)).ToString(@"hh\:mm\:ss");
            string duracaoTrabalho = TimeSpan.FromSeconds(await entradaRepo.PegarTotalTrabalhadoDia(dataAtual)).ToString(@"hh\:mm\:ss");
            string duracaoEstudo = TimeSpan.FromSeconds(await entradaRepo.PegarTotalEstudadoDia(dataAtual)).ToString(@"hh\:mm\:ss");

            txtTotalTime.Text = duracaoTotal;
            txtWorkTime.Text = duracaoTrabalho;
            txtStudyTime.Text = duracaoEstudo;
            txtBeggingTime.Text = tempoPendente;
            txtReleasedTime.Text = tempoLancado;
        }

        public async Task CarregarTarefas()
        {
            MostrarCarregamento(true);

            try
            {
                _tarefas = await _tarefaRepo.PegarTodasPorData(dataAtual);

                var entradaRepo = new EntradaRepo();
                var entradaLocalRepo = new EntradaLocalRepo();

                pnlTaskList.Controls.Clear();

                foreach (var tarefa in _tarefas)
                {
                    var duracaoTotal = await entradaRepo.PegarTotalTempoTarefa(tarefa.Id, dataAtual) +
                                       await entradaLocalRepo.PegarTotalTempoTarefa(tarefa.Id, dataAtual);

                    tarefa.Entradas = new List<Entrada>
                    {
                        new Entrada
                        {
                            TarefaId = tarefa.Id,
                            Duracao = duracaoTotal,
                            DataEntrada = dataAtual,
                        }
                    };

                    AdicionarCardTarefa(tarefa);
                }

                await ControlarTotalizadores();

                pnlTaskList.PerformLayout();
                pnlTaskList.Refresh();

                FiltrarTarefasPorData(dataAtual);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar tarefas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarCarregamento(false);
            }
        }

        private string PegarDescrTamanho(TamanhoE tamanho)
        {
            if (tamanho == TamanhoE.N)
                return "Sem tamanho";
            else
                return $"{tamanho}";
        }

        private void AdicionarCardTarefa(Tarefa tarefa)
        {
            var duracaoTotal = tarefa.Entradas?.Where(e => e.DataEntrada == dataAtual).Sum(e => e.Duracao) ?? 0;
            var duracaoFormatada = TimeSpan.FromSeconds(duracaoTotal).ToString(@"hh\:mm\:ss");

            var tarefaCard = new TaskCard
            {
                NumeroTarefa = tarefa.Id,
                TituloTarefa = tarefa.Titulo,
                TarefaTamanho = $"Tamanho estimado: {PegarDescrTamanho(tarefa.Tamanho)}",
                TemporizadorTexto = duracaoFormatada,
                Width = 300,
                Height = 150
            };

            tarefaCard.BotoesControle(dataAtual == DateOnly.FromDateTime(DateTime.Today));
            tarefaCard.ControleTempoAcionado += TaskCard_TimerControlClicked;

            int cardWidth = (pnlTaskList.ClientSize.Width - 40) / 2;
            tarefaCard.Width = cardWidth;
            tarefaCard.Height = 200;

            pnlTaskList.Controls.Add(tarefaCard);
        }

        private void TaskCard_TimerControlClicked(object sender, int taskNumber)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == taskNumber);

            if (tarefa != null)
            {
                var timeControlForm = new TimeControlForm(tarefa);

                Hide();
                timeControlForm.Show();
            }
        }

        private void txtTaskSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (Control control in pnlTaskList.Controls)
            {
                if (control is TaskCard taskCard)
                {
                    taskCard.Visible = taskCard.NumeroTarefa.ToString().Contains(txtTaskSearch.Text);
                }
            }
            pnlTaskList.PerformLayout();
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            await NavegarParaDataAsync(dataAtual.AddDays(-1));
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            await NavegarParaDataAsync(dataAtual.AddDays(1));
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            using (MonthCalendar calendario = new MonthCalendar())
            {
                calendario.MaxSelectionCount = 1;
                calendario.TodayDate = DateTime.Today;
                calendario.SelectionStart = dataAtual.ToDateTime(TimeOnly.MinValue);

                Size tamanhoCalendario = calendario.PreferredSize;

                Form formCalendario = new Form
                {
                    Text = "Selecione uma data",
                    Width = tamanhoCalendario.Width + 65,
                    Height = tamanhoCalendario.Height + 47,
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                };

                calendario.Dock = DockStyle.Fill;

                calendario.DateSelected += async (s, ev) =>
                {
                    formCalendario.Close();
                    await NavegarParaDataAsync(DateOnly.FromDateTime(ev.Start));
                };

                formCalendario.Controls.Add(calendario);
                formCalendario.ShowDialog();
            }
        }

        private async Task NavegarParaDataAsync(DateOnly novaData)
        {
            if (novaData == dataAtual)
                return;

            txtTaskSearch.Clear();
            MostrarCarregamento(true);

            try
            {
                dataAtual = novaData;
                AtualizarLabelData();

                await TarefaSync.Run(dataAtual);
                await CarregarTarefas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao navegar para nova data: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarCarregamento(false);
            }
        }

        private void FiltrarTarefasPorData(DateOnly data)
        {
            try
            {
                foreach (Control control in pnlTaskList.Controls)
                {
                    if (control is TaskCard taskCard)
                    {
                        var tarefa = _tarefas.FirstOrDefault(t => t.Id == taskCard.NumeroTarefa);
                        if (tarefa != null)
                            taskCard.Visible = data >= tarefa.DataInicial && data <= tarefa.DataFinal;
                    }
                }

                pnlTaskList.PerformLayout();
                pnlTaskList.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar tarefas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlTaskList_Resize(object sender, EventArgs e)
        {
            foreach (Control control in pnlTaskList.Controls)
            {
                int cardWidth = (pnlTaskList.ClientSize.Width - 40) / 2;
                control.Width = cardWidth;
                control.Height = 200;
            }
        }

        private async void btnRefreshTasks_Click(object sender, EventArgs e)
        {
            MostrarCarregamento(true);
            try
            {
                txtTaskSearch.Text = "";
                await TarefaSync.Run(dataAtual);
                await CarregarTarefas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar tarefas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarCarregamento(false);
            }
        }

        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            MostrarCarregamento(true);
            try
            {
                using (var inputForm = new InputForm())
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        var usuario = DadosUsuario.CarregarDadosUsuario();
                        Versao versao = await _versaoRepo.PegarVersaoPelaData(dataAtual);

                        if (await _tarefaRepo.Existe(int.Parse(inputForm.InputText)))
                        {
                            throw new Exception("A tarefa já existe para este usuário.");
                        }

                        if (inputForm.isCustom)
                        {
                            var novaTarefa = new Tarefa
                            {
                                Id = int.Parse(inputForm.InputText),
                                Titulo = inputForm.DescrText,
                                Descricao = "Tarefa customizada",
                                DataInicial = inputForm.StartDate,
                                DataFinal = inputForm.DueDate,
                                Tamanho = TamanhoE.N,
                                Status = "Nenhum",
                                Projeto = usuario.ProjetoId,
                                UsuarioId = usuario.Id,
                                VersaoId = versao.Id,
                                ProjetoVersaoId = versao.ProjetoId,
                            };
                            await _tarefaRepo.Adicionar(novaTarefa);

                            if (dataAtual < novaTarefa.DataInicial || dataAtual > novaTarefa.DataFinal)
                            {
                                MessageBox.Show(
                                    $"A tarefa foi adicionada, mas está entre as datas: {novaTarefa.DataInicial:dd/MM/yyyy} - {novaTarefa.DataFinal:dd/MM/yyyy}.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            await CarregarTarefas();
                            MessageBox.Show("Tarefa customizada adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (int.TryParse(inputForm.InputText, out int tarefaId))
                            {
                                try
                                {
                                    var servicoRedmine = new RedmineServ();
                                    var issue = await servicoRedmine.PegarIssue(tarefaId);
                                    if (issue != null)
                                    {
                                        await _tarefaRepo.AdicionarTarefaPorIssue(issue);
                                        if (dataAtual < issue.DataInicial || dataAtual > issue.DataFinal)
                                        {
                                            MessageBox.Show(
                                                $"A tarefa foi adicionada, mas está entre as datas: {issue.DataInicial:dd/MM/yyyy} - {issue.DataFinal:dd/MM/yyyy}.",
                                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        await CarregarTarefas();
                                        MessageBox.Show("Tarefa adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Tarefa não encontrada no Redmine.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Erro ao buscar a tarefa no Redmine: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("O número da tarefa informado é inválido. Por favor, insira um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        await ControlarTotalizadores();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar tarefa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarCarregamento(false);
                await ControlarTotalizadores();
            }
        }

        private async void btnReleaseTasks_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBeggingTime.Text == "00:00:00")
                    throw new Exception("Não existem horas pendentes de lançamento");

                EntradaLocalRepo entradaLocalRepo = new EntradaLocalRepo();
                var entradasLocais = await entradaLocalRepo.PegarTodosPorData(dataAtual);

                if (!entradasLocais.Any(x => x.Duracao >= 60))
                    throw new Exception("Não há registros pendentes de tempo com pelo menos um minuto de duração");

                var formLancamento = new ReleaseEntriesForm(dataAtual);

                await formLancamento.LoadDataAsync();
                formLancamento.PopulateGrid();
                formLancamento.ShowDialog();

                if (formLancamento.launchTasks)
                {
                    MostrarCarregamento(true);
                    await formLancamento.LaunchTasks();
                    await TarefaSync.Run(dataAtual);
                    await CarregarTarefas();
                    await ControlarTotalizadores();
                    MostrarCarregamento(false);
                    MessageBox.Show("Lançamento de horas realizado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao lançar horas: {ex.Message}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}