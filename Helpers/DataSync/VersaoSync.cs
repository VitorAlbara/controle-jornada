using controle_jornada.Models;
using controle_jornada.Repositories;
using controle_jornada.Services;

namespace controle_jornada.Helpers.DataSync
{
    public class VersaoSync
    {
        public static async Task Run(DateOnly data)
        {
            RedmineServ redmineServ = new RedmineServ();
            VersaoRepo versaoRepo   = new VersaoRepo();

            Versao? versao = await redmineServ.PegarVersaoAtual(data);

            if (versao == null) 
                throw new Exception("Nenhuma versão encontrada.");

            Versao? versaoExistente = await versaoRepo.PegarPeloId(versao.Id);

            if (versaoExistente == null)
                versaoRepo.Adicionar(versao);
            else
            {   
                versaoExistente.DataInicio     = versao.DataInicio;
                versaoExistente.DataVencimento = versao.DataVencimento;

                await versaoRepo.Atualizar(versaoExistente);
            }
        }
    }
}
