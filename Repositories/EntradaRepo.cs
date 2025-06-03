using controle_jornada.Helpers.AppData;
using controle_jornada.Infra.Context;
using controle_jornada.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace controle_jornada.Repositories

{
    public class EntradaRepo
    {
        private readonly ContextoBanco _contexto = new ContextoBanco();
        private readonly Usuario _usuario = DadosUsuario.CarregarDadosUsuario();
        public async Task AdicionarOuAtualizarDoRedmine(List<Entrada> entradasRedmine)
        {
            foreach (var entrada in entradasRedmine)
            {
                var entradaExistente = await _contexto.Entradas.FirstOrDefaultAsync(e => e.Id == entrada.Id);

                if (entradaExistente == null)
                    await _contexto.Entradas.AddAsync(entrada);
                else
                {
                    entradaExistente.Duracao     = entrada.Duracao;
                    entradaExistente.DataEntrada = entrada.DataEntrada;
                    entradaExistente.TarefaId    = entrada.TarefaId;
                    _contexto.Entradas.Update(entradaExistente);
                }
            }

            await _contexto.SaveChangesAsync();
        }

        public async Task<int> PegarProxIdNegativo()
        {
            int? menorIdNegativo = await _contexto.Entradas
                .Where(e => e.Id < 0)
                .OrderBy(e => e.Id)
                .Select(e => (int?)e.Id)
                .FirstOrDefaultAsync();

            if (menorIdNegativo.HasValue)
                return menorIdNegativo.Value - 1;
            else
                return -1;
        }

        public async Task<List<Entrada>> PegarTodosPorData(DateOnly data)
        {
            return await _contexto.Entradas
                .Include(e => e.Tarefa)
                .Where(e => e.TarefaUsuarioId == _usuario.Id && e.DataEntrada == data)
                .ToListAsync();
        }

        public async Task<int> PegarTotalTempoTarefa(int tarefaId, DateOnly data)
        {
            return await _contexto.Entradas
                .Include(e => e.Tarefa)
                .Where(e => e.TarefaUsuarioId == _usuario.Id
                        && e.TarefaId == tarefaId
                        && e.DataEntrada == data)
                .SumAsync(e => e.Duracao);
        }

        public async Task AdicionarOuAtualizar(Entrada entrada)
        {
            var entradaExistente = await _contexto.Entradas.FindAsync(entrada.Id);

            if (entradaExistente != null)
            {
                entradaExistente.Duracao = entrada.Duracao;
                _contexto.Entradas.Update(entradaExistente);
            }
            else
                _contexto.Entradas.Add(entrada);

            await _contexto.SaveChangesAsync();
        }

        public async Task<int> PegarTempoLancado(DateOnly data)
        {
            return await _contexto.Entradas
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id)
                .SumAsync(e => e.Duracao);
        }

        public async Task<int> PegarTotalGastoDia(DateOnly data)
        {
            return await _contexto.Entradas
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id)
                .SumAsync(e => e.Duracao) +
                await _contexto.EntradasLocais
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id)
                .SumAsync(e => e.Duracao);
        }

        public async Task<int> PegarTotalTrabalhadoDia(DateOnly data)
        {
            return await _contexto.Entradas
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id
                        && e.TarefaId != -1)
                .SumAsync(e => e.Duracao) +
                await _contexto.EntradasLocais
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id
                        && e.TarefaId != -1)
                .SumAsync(e => e.Duracao);
        }

        public async Task<int> PegarTotalEstudadoDia(DateOnly data)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _contexto.Entradas
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id
                        && e.TarefaId == -1)
                .SumAsync(e => e.Duracao) +
                await _contexto.EntradasLocais
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id
                        && e.TarefaId == -1)
                .SumAsync(e => e.Duracao);
        }

        public async Task<int> PegarTotalTempoGastoTarefa(int tarefaId)
        {
            return await _contexto.Entradas
                .Where(e => e.TarefaId == tarefaId && e.TarefaUsuarioId == _usuario.Id)
                .SumAsync(e => e.Duracao) +
                await _contexto.EntradasLocais
                .Where(e => e.TarefaId == tarefaId && e.TarefaUsuarioId == _usuario.Id)
                .SumAsync(e => e.Duracao);
        }

        public async Task Atualizar(Entrada entrada)
        {
            _contexto.Entradas.Update(entrada);
            await _contexto.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            var entrada = await _contexto.Entradas.FirstOrDefaultAsync(e => e.Id == id);

            if (entrada != null)
            {
                _contexto.Entradas.Remove(entrada);
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<Entrada?> PegarPorId(int id)
        {
            return await _contexto.Entradas.FindAsync(id);
        }
    }
}
