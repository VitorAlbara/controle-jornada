using controle_jornada.Models;
using Newtonsoft.Json;

namespace controle_jornada.Helpers.AppData
{
    public static class DadosUsuario
    {
        public static void SalvarDadosUsuario(Usuario usuario)
        {
            string filePath = AppDataHelper.GetArquivoUsuario();
            string json = JsonConvert.SerializeObject(usuario, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static Usuario CarregarDadosUsuario()
        {
            string filePath = AppDataHelper.GetArquivoUsuario();
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Usuario>(jsonContent);
            }
            return null;
        }
    }
}
