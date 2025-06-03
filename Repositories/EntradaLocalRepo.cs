using controle_jornada.Helpers.AppData;
using controle_jornada.Infra.Context;
using controle_jornada.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Windows.Forms;

namespace controle_jornada.Repositories
{
   public class LocalEntriesRepo
    {
        private readonly ContextoBanco _context = new ContextoBanco();

        public async System.Threading.Tasks.Task Add(EntradaLocal localEntrie)
        {
            var existingEntry = await _context.EntradasLocais
                    .Where(e => e.DataEntrada == DateOnly.FromDateTime(DateTime.Now)
                            && e.TarefaId == localEntrie.TarefaId
                            && e.TarefaUsuarioId == localEntrie.TarefaUsuarioId)
                    .FirstOrDefaultAsync();

            if (existingEntry != null)
            {
                existingEntry.Duracao = localEntrie.Duracao;
                _context.EntradasLocais.Update(existingEntry);
            }
            else
                _context.EntradasLocais.Add(localEntrie);

            await _context.SaveChangesAsync();
        }

        public async Task<List<EntradaLocal>> GetAllPerDate(DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.EntradasLocais
                .Include(e => e.Tarefa)
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id)
                .ToListAsync();
        }


        public async Task<int> GetTotalTimeByTaskAndDate(int taskId, DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.EntradasLocais
                .Include(e => e.Tarefa)
                .Where(e => e.TarefaUsuarioId == user.Id
                        && e.TarefaId == taskId
                        && e.DataEntrada == date)
                .SumAsync(e => e.Duracao);
        }

        public async Task<int> GetRealesedTime(DateOnly date)
        {
            var user = DadosUsuario.CarregarDadosUsuario();

            return await _context.EntradasLocais
                .Where(e => e.DataEntrada == date && e.TarefaUsuarioId == user.Id)
                .SumAsync(e => e.Duracao);
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var localEntrie = await _context.EntradasLocais.FirstOrDefaultAsync(e => e.Id == id);

            if (localEntrie != null)
            {
                _context.EntradasLocais.Remove(localEntrie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
