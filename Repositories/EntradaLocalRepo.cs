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
        private readonly Usuario _usuario = DadosUsuario.CarregarDadosUsuario();

        public async Task AdicionarOuAtualizar(EntradaLocal entradaLocal)
        {
            var entradaExistente = await _context.EntradasLocais
                    .Where(e => e.DataEntrada == DateOnly.FromDateTime(DateTime.Now)
                            && e.TarefaId == entradaLocal.TarefaId
                            && e.TarefaUsuarioId == entradaLocal.TarefaUsuarioId)
                    .FirstOrDefaultAsync();

            if (entradaExistente != null)
            {
                entradaExistente.Duracao = entradaLocal.Duracao;
                _context.EntradasLocais.Update(entradaExistente);
            }
            else
                _context.EntradasLocais.Add(entradaLocal);

            await _context.SaveChangesAsync();
        }

        public async Task<List<EntradaLocal>> PegarTodosPorData(DateOnly data)
        {
            return await _context.EntradasLocais
                .Include(e => e.Tarefa)
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id)
                .ToListAsync();
        }

        public async Task<int> PegarTotalTempoTarefa(int tarefaId, DateOnly data)
        {
            return await _context.EntradasLocais
                .Include(e => e.Tarefa)
                .Where(e => e.TarefaUsuarioId == _usuario.Id
                        && e.TarefaId == tarefaId
                        && e.DataEntrada == data)
                .SumAsync(e => e.Duracao);
        }

        public async Task<int> PegarTempoLancado(DateOnly data)
        {
            return await _context.EntradasLocais
                .Where(e => e.DataEntrada == data && e.TarefaUsuarioId == _usuario.Id)
                .SumAsync(e => e.Duracao);
        }

        public async Task Deletar(int id)
        {
            var entradaLocal = await _context.EntradasLocais.FirstOrDefaultAsync(e => e.Id == id);

            if (entradaLocal != null)
            {
                _context.EntradasLocais.Remove(entradaLocal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
