using System.Windows.Forms;
using controle_jornada.Infra.Context;
using controle_jornada.Models;
using Microsoft.EntityFrameworkCore;

namespace controle_jornada.Repositories
{
    public class ProjetoRepo
    {
        private readonly ContextoBanco _context = new ContextoBanco();

        public async Task<List<Projeto>> GetAll()
        {
            return await _context.Projetos.Where(p => p.Id != 0).ToListAsync();
        }
    }
}
