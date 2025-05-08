namespace controle_jornada.Helpers.AppData
{
    public static class AppDataHelper
    {
        private static readonly string AppDataCaminho = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "controle-jornada"
        );

        public static string GetPastaAppData()
        {
            if (!Directory.Exists(AppDataCaminho))
                Directory.CreateDirectory(AppDataCaminho);

            return AppDataCaminho;
        }

        public static string GetArquivoUsuario()
        {
            return Path.Combine(GetPastaAppData(), "usuario.json");
        }
    }
}
