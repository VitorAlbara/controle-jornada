using controle_jornada.Enums;
using controle_jornada.Helpers.AppData;
using controle_jornada.Infra.Context;
using controle_jornada.Models;
using Microsoft.EntityFrameworkCore;

namespace controle_jornada.Repositories
{
    public class TarefaRepo
    {
        private readonly ContextoBanco _contexto  = new ContextoBanco();
        private readonly Usuario _usuario = DadosUsuario.CarregarDadosUsuario();

        public async Task<bool> ExistePorVersao(int versaoId)
        {
            return await _contexto.Tarefas
                            .Where(t => t.UsuarioId == _usuario.Id && t.VersaoId == versaoId)
                            .AnyAsync();
        }
        public async Task<bool> Existe(int id)
        {
            return await _contexto.Tarefas
                .Where(t => t.Id == id && t.UsuarioId == _usuario.Id)
                .AnyAsync();
        }

        public async Task<bool> ExisteTarefaEstudo()
        {
            return await _contexto.Tarefas
                .Where(t => t.UsuarioId == _usuario.Id && t.Id == -1)
                .AnyAsync();
        }

        public async Task AdicionarIntervalo(List<Tarefa> tarefas)
        {
            _contexto.Tarefas.AddRange(tarefas);
            await _contexto.SaveChangesAsync();
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            _contexto.Tarefas.Add(tarefa);
            await _contexto.SaveChangesAsync();
        }

        public async Task AdicionarTarefaPorIssue(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue), "A issue não pode ser nula!");

            var tarefaExistente = await _contexto.Tarefas
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == issue.Id);

            var dataInicial = issue.DataInicial ?? DateOnly.MinValue;
            var dataFinal = issue.DataFinal ?? DateOnly.MaxValue;

            if (tarefaExistente != null)
            {   
                tarefaExistente.Titulo      = issue.Assunto;
                tarefaExistente.Descricao   = issue.Descricao ?? "Sem descrição.";
                tarefaExistente.DataInicial = dataInicial;
                tarefaExistente.DataFinal   = dataFinal;
                tarefaExistente.Tamanho     = TamanhoEnum.PegarTamanho(issue.Tamanho);
                tarefaExistente.Status      = issue.Status;

                _contexto.Entry(tarefaExistente).State = EntityState.Modified;
            }
            else
            {
                var novaTarefa = new Tarefa
                {
                    Id              = issue.Id
                  , Titulo          = issue.Assunto
                  , Descricao       = issue.Descricao ?? "Sem descrição."
                  , DataInicial     = dataInicial
                  , DataFinal       = dataFinal
                  , Tamanho         = TamanhoEnum.PegarTamanho(issue.Tamanho)
                  , Status          = issue.Status
                  , Projeto         = issue.ProjetoId
                  , UsuarioId       = _usuario.Id
                  , VersaoId        = issue.VersaoFixa
                  , ProjetoVersaoId = issue.ProjetoId
                };

                await _contexto.Tarefas.AddAsync(novaTarefa);
            }

            await _contexto.SaveChangesAsync();
        }

        public async Task<ICollection<Tarefa>> PegarTodasPorData(DateOnly data)
        {
            return await _contexto.Tarefas
                .Include(t => t.Entradas)
                .Include(t => t.EntradasLocais)
                .Where(t => t.UsuarioId == _usuario.Id
                        && t.DataInicial <= data
                        && t.DataFinal >= data)
                .ToListAsync();
        }

        public async Task<ICollection<Tarefa>> PegarTodasPorVersao(int versaoId)
        {
            return await _contexto.Tarefas
                .Include(t => t.Entradas)
                .Include(t => t.EntradasLocais)
                .Where(t => t.UsuarioId == _usuario.Id && t.VersaoId == versaoId)
                .ToListAsync();
        }

        public async Task RemoverIntervalo(List<Tarefa> tarefas)
        {
            _contexto.Tarefas.RemoveRange(tarefas);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarIntervalo(List<Tarefa> tarefas)
        {
            _contexto.Tarefas.UpdateRange(tarefas);
            await _contexto.SaveChangesAsync();
        }
    }
}
