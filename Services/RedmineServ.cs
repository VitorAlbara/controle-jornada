using controle_jornada.Helpers.AppData;
using controle_jornada.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

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
                        DateOnly dataFinal  = DateOnly.Parse((string)issue.due_date);

                        if (data >= dataInicio && data <= dataFinal)
                        {
                            return new Versao
                            {
                                Id             = (int)issue.fixed_version.id,
                                ProjetoId      = _usuario.ProjetoId,
                                DataInicio     = dataInicio,
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
                        var dados   = JsonConvert.DeserializeObject<dynamic>(json);

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
                                    Id          = (int)issue.id,
                                    Assunto     = issue.subject?.ToString() ?? "Sem título",
                                    Descricao   = issue.description?.ToString() ?? "Sem descrição.",
                                    ProjetoId   = issue.project?.id ?? 0,
                                    DataInicial = issue.start_date != null ? DateOnly.Parse((string)issue.start_date) : (DateOnly?)null,
                                    DataFinal   = issue.due_date   != null ? DateOnly.Parse((string)issue.due_date) : (DateOnly?)null,
                                    Tamanho     = tamanho,
                                    VersaoFixa  = versaoId,
                                    Status      = issue.status?.name?.ToString() ?? "Desconhecido"
                                });
                            }
                        }
                    } else
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

                    HttpResponseMessage response = await cliente.GetAsync($"{baseUrl}/issues/{tarefaId}.json");

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var dados   = JsonConvert.DeserializeObject<dynamic>(json);

                        var issue = dados.issue;

                        string tamaho = "N/A";

                        if (issue.custom_fields != null)
                        {
                            foreach (var campo in issue.custom_fields)
                            {
                                if (campo.id == 127)
                                {
                                    tamaho = campo.value ?? "N/A";
                                    break;
                                }

                                int projetoId = issue.project.id ?? 0;
                                int versaoFixa = 0;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar a tarefa {tarefaId}: {ex.Message}");
                return null;
            }
    }
}
