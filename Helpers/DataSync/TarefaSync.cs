using controle_jornada.Enums;
using controle_jornada.Helpers.AppData;
using controle_jornada.Models;
using controle_jornada.Repositories;
using controle_jornada.Services;

namespace controle_jornada.Helpers.DataSync
{
    public class TarefaSync
    {
        public static async Task Run(DateOnly data)
        {
            Usuario usuario = DadosUsuario.CarregarDadosUsuario();
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            VersaoRepo  versaoRepo  = new VersaoRepo();
            TarefaRepo  tarefaRepo  = new TarefaRepo();
            EntradaRepo entradaRepo = new EntradaRepo();
            RedmineServ redmineServ = new RedmineServ();

            Versao? versao = await versaoRepo.PegarVersaoPelaData(data);

            var issues            = await redmineServ.PegarIssues(versao.Id) ?? new List<Issue>();
            var tarefasExistentes = await tarefaRepo.PegarTodasPorVersao(versao.Id);

            var tarefasParaAdicionar = issues
                .Where(issue => tarefasExistentes.All(et => et.Id != issue.Id))
                .Select(issue => CriarTarefaPelaIssue(issue, versao, usuario.Id))
                .ToList();

            var tarefasParaAtualizar = tarefasExistentes
                .Where(et => issues.Any(issue => issue.Id == et.Id))
                .ToList();

            foreach (var tarefa in tarefasParaAtualizar)
            {
                var issue = issues.First(i => i.Id == tarefa.Id);
                AtualizarTarefaPelaIssue(tarefa, issue);
            }

            if (!tarefasExistentes.Any(t => t.Id == -1) && !await tarefaRepo.ExisteTarefaEstudo())
            {
                tarefasParaAdicionar.Add(new Tarefa
                {
                    Id = -1,
                    Titulo = "Estudo",
                    Descricao = "Informe o tempo gasto em sua hora de estudo!",
                    Status = "Geral",
                    Tamanho = TamanhoE.P,
                    DataInicial = DateOnly.MaxValue,
                    DataFinal = DateOnly.MinValue,
                    UsuarioId = usuario.Id,
                    VersaoId = versao.Id,
                    ProjetoVersaoId = versao.ProjetoId,
                });
            }

            await tarefaRepo.AdicionarIntervalo(tarefasParaAdicionar);
            await tarefaRepo.AtualizarIntervalo(tarefasParaAtualizar);

            var entradasRedmine    = await redmineServ.PegarEntradasTempo(data);
            var entradasExistentes = await entradaRepo.PegarTodosPorData(data);

            foreach (var entrada in entradasRedmine)
            {
                var entradaLocal = await entradaRepo.PegarPorId(entrada.Id);

                if (entradaLocal != null)
                {
                    entradaLocal.TarefaId    = entrada.TarefaId;
                    entradaLocal.DataEntrada = entrada.DataEntrada;
                    entradaLocal.Duracao     = entrada.Duracao;
                    await entradaRepo.Atualizar(entradaLocal);
                }
                else
                {
                    if (!await tarefaRepo.Existe(entrada.TarefaId))
                    {
                        var issue = await redmineServ.PegarIssue(entrada.TarefaId);
                        if (issue != null && issue.VersaoFixa == versao.Id)
                        {
                            var novaTarefa = CriarTarefaPelaIssue(issue, versao, usuario.Id);
                            await tarefaRepo.Adicionar(novaTarefa);
                        }
                    }

                    if (await tarefaRepo.Existe(entrada.TarefaId))
                        await entradaRepo.AdicionarOuAtualizar(entrada);
                }
            }

            var idsEntradasRedmine = entradasRedmine.Select(e => e.Id).ToList();
            var entradasParaRemover = entradasExistentes
                .Where(e => !idsEntradasRedmine.Contains(e.Id))
                .ToList();

            foreach (var entradaParaRemover in entradasParaRemover)
            {
                if (entradaParaRemover.TarefaId == -1)
                    continue;

                await entradaRepo.Deletar(entradaParaRemover.Id);
            }
        }

        private static Tarefa CriarTarefaPelaIssue(dynamic issue, Versao versao, int usuarioId)
        {
            return new Tarefa
            {
                Id              = issue.Id,
                Titulo          = issue.Subject,
                Descricao       = issue.Description ?? "Nenhuma descrição.",
                Tamanho         = TamanhoEnum.PegarTamanho(issue.Size),
                Status          = issue.Status,
                DataInicial     = versao.DataInicio,
                DataFinal       = versao.DataVencimento,
                UsuarioId       = usuarioId,
                VersaoId        = versao.Id,
                ProjetoVersaoId = versao.ProjetoId
            };
        }

        private static void AtualizarTarefaPelaIssue(Tarefa tarefa, Issue issue)
        {
            tarefa.Titulo      = issue.Assunto;
            tarefa.Descricao   = issue.Descricao   ?? tarefa.Descricao;
            tarefa.Status      = issue.Status      ?? tarefa.Status;
            tarefa.DataInicial = issue.DataInicial ?? tarefa.DataInicial;
            tarefa.DataFinal   = issue.DataFinal   ?? tarefa.DataFinal;
        }
    }
}
