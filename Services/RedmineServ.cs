using controle_jornada.Helpers.AppData;
using controle_jornada.Models;
using controle_jornada.Repositories;
using Newtonsoft.Json;
using System.Globalization;

namespace controle_jornada.Services
{
    class RedmineServ
    {
        private readonly string baseUrl = "https://redmine.questor.com.br";
        private readonly Usuario _usuario = DadosUsuario.CarregarDadosUsuario();

        public async Task<Usuario?> PegarUsuario(string chaveApi)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("X-Redmine-API-Key", chaveApi);

                HttpResponseMessage resposta = await cliente.GetAsync($"{baseUrl}/users/current.json");

                if (resposta.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Usuario>(
                        JsonConvert.DeserializeObject<dynamic>(
                            await resposta.Content.ReadAsStringAsync()
                        ).user.ToString()
                    );

                return null;
            }
        }

        public async Task<Versao?> PegarVersaoAtual(DateOnly data)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("X-Redmine-API-Key", _usuario.ChaveApi);

                var resposta = await cliente.GetAsync($"{baseUrl}/issues.json?assigned_to_id={_usuario.Id}&project_id={_usuario.ProjetoId}&status_id=*&limit=100");
                if (resposta.IsSuccessStatusCode)
                {
                    string json = await resposta.Content.ReadAsStringAsync();
                    var dados = JsonConvert.DeserializeObject<dynamic>(json);

                    foreach (var issue in dados.issues)
                    {
                        DateOnly dataInicio = DateOnly.Parse((string)issue.start_date);
                        DateOnly dataFinal = DateOnly.Parse((string)issue.due_date);

                        if (data >= dataInicio && data <= dataFinal)
                        {
                            return new Versao
                            {
                                Id = (int)issue.fixed_version.id,
                                ProjetoId = _usuario.ProjetoId,
                                DataInicio = dataInicio,
                                DataVencimento = dataFinal
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<Issue>> PegarIssues(int versaoId)
        {
            var issues = new List<Issue>();

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Add("X-Redmine-API-Key", _usuario.ChaveApi);

                    HttpResponseMessage resposta = await cliente.GetAsync($"{baseUrl}/issues.json?assigned_to_id={_usuario.Id}&status_id=*&fixed_version_id={versaoId}&limit=100");

                    if (resposta.IsSuccessStatusCode)
                    {
                        string json = await resposta.Content.ReadAsStringAsync();
                        var dados = JsonConvert.DeserializeObject<dynamic>(json);

                        foreach (var issue in dados.issues)
                        {
                            if (issue.fixed_version != null && issue.fixed_version.id == versaoId)
                            {
                                string tamanho = "N/A";

                                if (issue.custom_fields != null)
                                {
                                    foreach (var campo in issue.custom_fields)
                                    {
                                        if (campo.id == 127)
                                        {
                                            tamanho = campo.value ?? "N/A";
                                            break;
                                        }
                                    }
                                }

                                issues.Add(new Issue
                                {
                                    Id = (int)issue.id,
                                    Assunto = issue.subject?.ToString() ?? "Sem título",
                                    Descricao = issue.description?.ToString() ?? "Sem descrição.",
                                    ProjetoId = issue.project?.id ?? 0,
                                    DataInicial = issue.start_date != null ? DateOnly.Parse((string)issue.start_date) : (DateOnly?)null,
                                    DataFinal = issue.due_date != null ? DateOnly.Parse((string)issue.due_date) : (DateOnly?)null,
                                    Tamanho = tamanho,
                                    VersaoFixa = versaoId,
                                    Status = issue.status?.name?.ToString() ?? "Desconhecido"
                                });
                            }
                        }
                    }
                    else
                    {
                        throw new Exception($"Erro na requisição: {resposta.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter tarefas: {ex.Message}");
            }

            return issues;
        }

        public async Task<Issue?> PegarIssue(int tarefaId)
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Add("X-Redmine-API-Key", _usuario.ChaveApi);

                    HttpResponseMessage resposta = await cliente.GetAsync($"{baseUrl}/issues/{tarefaId}.json");

                    if (resposta.IsSuccessStatusCode)
                    {
                        string json = await resposta.Content.ReadAsStringAsync();
                        var dados = JsonConvert.DeserializeObject<dynamic>(json);

                        var issue = dados.issue;

                        string tamanho = "N/A";

                        if (issue.custom_fields != null)
                        {
                            foreach (var campo in issue.custom_fields)
                            {
                                if (campo.id == 127)
                                {
                                    tamanho = campo.value ?? "N/A";
                                    break;
                                }
                            }
                        }

                        int projetoId = issue.project.id ?? 0;
                        int versaoFixa = 0;
                        var versaoRepo = new VersaoRepo();

                        if (issue.fixed_version == null)
                        {
                            var versao = await versaoRepo.PegarOuCriarVersaoPadrao(projetoId);
                            versaoFixa = versao?.Id ?? 0;
                        }
                        else
                        {
                            versaoFixa = (int)issue.fixed_version.id;
                        }

                        return new Issue
                        {
                            Id = (int)issue.id,
                            Assunto = issue.subject?.ToString() ?? "Sem título",
                            Descricao = issue.description?.ToString() ?? "Sem descrição",
                            ProjetoId = projetoId,
                            DataInicial = issue.start_date != null ? DateOnly.Parse((string)issue.start_date) : (DateOnly?)null,
                            DataFinal = issue.due_date != null ? DateOnly.Parse((string)issue.due_date) : (DateOnly?)null,
                            Tamanho = tamanho,
                            VersaoFixa = versaoFixa,
                            Status = issue.status?.name ?? "Desconhecido"
                        };
                    }
                    else
                    {
                        throw new Exception($"Erro ao buscar a tarefa {tarefaId}: {resposta.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar a tarefa {tarefaId}: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Entrada>> PegarEntradasTempo(DateOnly data)
        {
            var entradas = new List<Entrada>();

            try
            {
                if (_usuario == null)
                    throw new Exception("Usuário não encontrado.");

                using (HttpClient cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Add("X-Redmine-API-Key", _usuario.ChaveApi);

                    string primeiroDiaMes = new DateTime(data.Year, data.Month, 1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string ultimoDiaMes   = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month)).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                    HttpResponseMessage resposta = await cliente.GetAsync($"{baseUrl}/time_entries.json?user_id={_usuario.Id}&from={primeiroDiaMes}&to={ultimoDiaMes}");

                    if (!resposta.IsSuccessStatusCode)
                        throw new Exception($"Erro na requisição ao Redmine: {resposta.StatusCode}");

                    string json = await resposta.Content.ReadAsStringAsync();
                    var dados = JsonConvert.DeserializeObject<dynamic>(json);

                    foreach (var entradaTempo in dados.time_entries)
                    {
                        if (entradaTempo.hours == null || entradaTempo.spent_on == null)
                            continue;

                        string dataGastaStr = (string)entradaTempo.spent_on;
                        if (!DateOnly.TryParse(dataGastaStr, out DateOnly dataGasta))
                            continue;

                        double horas = (double)entradaTempo.hours;
                        int duracaoSegundos = (int)(horas * 3600);

                        int idEntradaRedmine = (int)entradaTempo.id;

                        if (entradaTempo.issue != null && entradaTempo.issue.id != null)
                        {
                            int idIssue = (int)entradaTempo.issue.id;
                            if (idIssue > 0)
                            {
                                entradas.Add(new Entrada
                                {
                                    Id = idEntradaRedmine,
                                    TarefaId = idIssue,
                                    TarefaUsuarioId = _usuario.Id,
                                    DataEntrada = dataGasta,
                                    Duracao = duracaoSegundos,
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar entradas de tempo: {ex.Message}");
            }

            return entradas;
        }

        public async Task<List<Atividade>> PegarAtividades()
        {
            var atividades = new List<Atividade>();

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Add("X-Redmine-API-Key", _usuario.ChaveApi);

                    var resposta = await cliente.GetAsync($"{baseUrl}/enumerations/time_entry_activities.json");

                    if (resposta.IsSuccessStatusCode)
                    {
                        var json = await resposta.Content.ReadAsStringAsync();
                        var dados = JsonConvert.DeserializeObject<dynamic>(json);

                        foreach (var atividade in dados.time_entry_activities)
                        {
                            atividades.Add(new Atividade
                            {
                                Id = (int)atividade.id,
                                Nome = (string)atividade.name
                            });
                        }
                    }
                    else
                    {
                        throw new Exception($"Erro ao obter atividades: {resposta.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return atividades;
        }
    }
}
