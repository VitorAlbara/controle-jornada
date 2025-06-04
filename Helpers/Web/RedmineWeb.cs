using System.Diagnostics;

namespace controle_jornada.Helpers.Web
{
    public class RedmineWeb
    {
        private const string UrlBase = "https://redmine.questor.com.br/issues/";

        public static void AbrirTarefaNoNavegador(int tarefaId)
        {
            try
            {
                string url = $"{UrlBase}{tarefaId}";
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao abrir o link do Redmine: {ex.Message}");
            }
        }
    }
}
