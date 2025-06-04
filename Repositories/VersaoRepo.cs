using controle_jornada.Helpers.AppData;
using controle_jornada.Infra.Context;
using controle_jornada.Models;
using Microsoft.EntityFrameworkCore;

namespace controle_jornada.Repositories
{
    public class VersaoRepo
    {
        private readonly ContextoBanco _contexto = new ContextoBanco();
        private readonly Usuario _usuario = DadosUsuario.CarregarDadosUsuario();

        public async void Adicionar(Versao versao)
        {
            _contexto.Versoes.Add(versao);
            await _contexto.SaveChangesAsync();
        }

        public async Task<bool> Existe(int versaoId)
        {
            return await _contexto.Versoes
                            .Where(v => v.Id == versaoId && v.ProjetoId == _usuario.ProjetoId)
                            .AnyAsync();
        }

        public async Task<List<Versao>> PegarVersoesPelaData(DateOnly data)
        {
            return await _contexto.Versoes
                            .Where(v => v.DataInicio <= data && v.DataVencimento >= data && v.ProjetoId == _usuario.ProjetoId)
                            .ToListAsync();
        }

        public async Task<Versao> PegarVersaoPelaData(DateOnly data)
        {
            return await _contexto.Versoes
                            .Where(v => v.DataInicio <= data && v.DataVencimento >= data && v.ProjetoId == _usuario.ProjetoId)
                            .FirstAsync();
        }

        public async Task<Versao?> PegarPeloId(int id)
        {
            return await _contexto.Versoes
                            .Where(v => v.Id == id && v.ProjetoId == _usuario.ProjetoId)
                            .FirstOrDefaultAsync();
        }

        public async Task Atualizar(Versao versao)
        {
            _contexto.Versoes.Update(versao);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Versao> PegarOuCriarVersaoPadrao(int projetoId)
        {
            var versaoPadrao = await _contexto.Versoes
                .FirstOrDefaultAsync(v => v.ProjetoId == projetoId && v.Id == 0);

            if (versaoPadrao == null)
            {
                versaoPadrao = new Versao
                {
                    Id             = 0,
                    Nome           = "Default",
                    ProjetoId      = projetoId,
                    DataInicio     = DateOnly.MinValue,
                    DataVencimento = DateOnly.MaxValue,
                };

                await _contexto.Versoes.AddAsync(versaoPadrao);
                await _contexto.SaveChangesAsync();
            }

            return versaoPadrao;
        }
    }
}
