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
        private readonly ContextoBanco _context = new ContextoBanco();

        public async System.Threading.Tasks.Task AddOrUpdateFromRedmine(List<Entrada> redmineEntries)
        {
            foreach (var entry in redmineEntries)
            {
                var existingEntry = await _context.Entradas.FirstOrDefaultAsync(e => e.Id == entry.Id);

                if (existingEntry == null)
                    await _context.Entradas.AddAsync(entry);
                else
                {
                    existingEntry.Duracao = entry.Duracao;
                    existingEntry.DataEntrada = entry.DataEntrada;
                    existingEntry.TarefaId = entry.TarefaId;
                    _context.Entradas.Update(existingEntry);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetNextNegativeIdAsync()
        {
            int? smallestNegativeId = await _context.Entradas
                .Where(e => e.Id < 0)
                .OrderBy(e => e.Id)
                .Select(e => (int?)e.Id)
                .FirstOrDefaultAsync();

            if (smallestNegativeId.HasValue)
                return smallestNegativeId.Value - 1;
            else
                return -1;
        }

        public async Task<List<Entrada>> GetEntriesByUserAndDate(DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.Entradas
                .Include(e => e.Tarefa)
                .Where(e => e.TarefaUsuarioId == user.Id && e.DataEntrada == date)
                .ToListAsync();
        }

        public async Task<int> GetTotalTimeByTaskAndDate(int tarefaId, DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.Entradas
                .Include(e => e.Tarefa)
                .Where(e => e.TarefaUsuarioId == user.Id
                        && e.TarefaId == tarefaId
                        && e.DataEntrada == date)
                .SumAsync(e => e.Duracao);
        }

        public async System.Threading.Tasks.Task Add(Entrada entry)
        {
            var existingEntry = await _context.Entradas.FindAsync(entry.Id);

            if (existingEntry != null)
            {
                existingEntry.Duracao = entry.Duracao;
                _context.Entradas.Update(existingEntry);
            }
            else
                _context.Entradas.Add(entry);

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetRealesedTime(DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.Entradas
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id)
                .SumAsync(e => e.Duracao);
        }

        public async Task<int> GetTotalSpentTimePerDate(DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.Entradas
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id)
                .SumAsync(e => e.Duracao) +
                await _context.EntradasLocais
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id)
                .SumAsync(e => e.Duracao);
        }

        public async Task<int> GetWorkTimeSpentPerDate(DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.Entradas
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id
                        && e.TarefaId != "Estudo")
                .SumAsync(e => e.Duration) +
                await _context.EntradasLocais
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id
                        && e.TarefaId != "Estudo")
                .SumAsync(e => e.Duration);
        }

        public async Task<int> GetStudyTimeSpentPerDate(DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.Entradas
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id
                        && e.TarefaId == "Estudo")
                .SumAsync(e => e.Duration) +
                await _context.EntradasLocais
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id
                        && e.TarefaId == "Estudo")
                .SumAsync(e => e.Duration);
        }

        public async Task<int> GetTotalSpentTimeByTask(int taskId)
        {
            var user = DadosUsuario.CarregarDadosUsuario();
            return await _context.Entradas
                .Where(e => e.TarefaId == taskId && e.TarefaUsuarioId == user.Id)
                .SumAsync(e => e.Duracao) +
                await _context.EntradasLocais
                .Where(e => e.TarefaId == taskId && e.TarefaUsuarioId == user.Id)
                .SumAsync(e => e.Duracao);
        }

        public async System.Threading.Tasks.Task Update(Entrada entrie)
        {
            _context.Entradas.Update(entrie);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var entrie = await _context.Entradas.FirstOrDefaultAsync(e => e.Id == id);

            if (entrie != null)
            {
                _context.Entradas.Remove(entrie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Entrada?> FindByIdAsync(int id)
        {
            return await _context.Entradas.FindAsync(id);
        }
    }
}
