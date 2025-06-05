using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

#nullable disable

namespace controle_jornada.Migrations
{
    /// <inheritdoc />
    public partial class SeedInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Task.Run(async () =>
            {
                var dados = await PegarProjetosDaApi();

                foreach (var projeto in dados)
                {
                    migrationBuilder.Sql($@"
                        INSERT INTO projetos (""Id"", ""Nome"")
                        VALUES ({projeto.Id}, '{projeto.Nome.Replace("'", "''")}')
                        ON CONFLICT (""Id"") DO NOTHING;
                    ");

                    foreach (var versao in projeto.Versoes)
                    {
                        migrationBuilder.Sql($@"
                            INSERT INTO versoes (""Id"", ""Nome"", ""DataInicio"", ""DataVencimento"", ""ProjetoId"")
                            VALUES ({versao.Id}, '{versao.Nome.Replace("'", "''")}', 
                                    '{versao.DataInicio:yyyy-MM-dd}', 
                                    '{versao.DataVencimento:yyyy-MM-dd}', 
                                    {projeto.Id})
                            ON CONFLICT (""Id"", ""ProjetoId"") DO NOTHING;
                        ");
                    }
                }
            }).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM versoes");
            migrationBuilder.Sql("DELETE FROM projetos");
        }

        private async Task<List<ProjetoModel>> PegarProjetosDaApi()
        {
            var chaveApiUsuario = "f62aa45cac769781b1f04d76824dcc364a2781e1";
            var urlBase = "https://redmine.questor.com.br";

            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("X-Redmine-API-Key", chaveApiUsuario);

                var projetos = new List<ProjetoModel>();
                int offset = 0;
                const int limit = 100;
                bool temMais = true;

                while (temMais)
                {
                    HttpResponseMessage resposta = await cliente.GetAsync($"{urlBase}/projects.json?offset={offset}&limit={limit}");
                    if (!resposta.IsSuccessStatusCode)
                        throw new Exception($"Erro ao buscar projetos: {resposta.StatusCode}");

                    string projetoJson = await resposta.Content.ReadAsStringAsync();
                    var dadosProjeto = JsonConvert.DeserializeObject<dynamic>(projetoJson);

                    foreach (var projeto in dadosProjeto.projects)
                    {
                        var projetoId = (int)projeto.id;
                        var nomeProjeto = (string)projeto.name;

                        var versoes = await PegarVersoesDaApi(cliente, urlBase, projetoId);

                        projetos.Add(new ProjetoModel
                        {
                            Id = projetoId,
                            Nome = nomeProjeto,
                            Versoes = versoes
                        });
                    }

                    offset += limit;
                    temMais = dadosProjeto.total_count > offset;
                }

                return projetos;
            }
        }

        private async Task<List<VersaoModel>> PegarVersoesDaApi(HttpClient cliente, string urlBase, int projetoId)
        {
            var versoes = new List<VersaoModel>();

            HttpResponseMessage resposta = await cliente.GetAsync($"{urlBase}/projects/{projetoId}/versions.json");
            if (resposta.IsSuccessStatusCode)
            {
                string versaoJson = await resposta.Content.ReadAsStringAsync();
                var dadosVersao = JsonConvert.DeserializeObject<dynamic>(versaoJson);

                foreach (var versao in dadosVersao.versions)
                {
                    DateOnly? dataInicio = null;
                    DateOnly? dataVencimento = null;

                    var campoCustomizado = versao.custom_fields as IEnumerable<dynamic>;
                    if (campoCustomizado != null)
                    {
                        var campoDataInicio = campoCustomizado.FirstOrDefault(field => (string)field.name == "Data Início");
                        if (campoDataInicio != null && !string.IsNullOrEmpty((string)campoDataInicio.value))
                        {
                            dataInicio = DateOnly.FromDateTime(DateTime.Parse((string)campoDataInicio.value).ToUniversalTime());
                        }

                        var campoDataVencimento = campoCustomizado.FirstOrDefault(field => (string)field.name == "Data de Produção");
                        if (campoDataVencimento != null && !string.IsNullOrEmpty((string)campoDataVencimento.value))
                        {
                            dataVencimento = DateOnly.FromDateTime(DateTime.Parse((string)campoDataVencimento.value).ToUniversalTime());
                        }
                    }

                    if (dataInicio.HasValue && dataVencimento.HasValue)
                    {
                        versoes.Add(new VersaoModel
                        {
                            Id = (int)versao.id,
                            Nome = (string)versao.name,
                            DataInicio = dataInicio.Value,
                            DataVencimento = dataVencimento.Value
                        });
                    }
                }
            }
            else
            {
                Console.WriteLine($"Erro ao buscar versões para o projeto {projetoId}: {resposta.StatusCode}");
            }

            return versoes;
        }

        private class ProjetoModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public List<VersaoModel> Versoes { get; set; }
        }

        private class VersaoModel
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public DateOnly DataInicio { get; set; }
            public DateOnly DataVencimento { get; set; }
        }
    }
}
