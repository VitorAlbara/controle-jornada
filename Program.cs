using controle_jornada.Helpers.AppData;
using controle_jornada.Views;

namespace controle_jornada
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var user = DadosUsuario.CarregarDadosUsuario();

            if (user != null)
            {
                Application.Run(new MainForm());
            }
            else
            {
                using (var apiKeyForm = new ApiKeyForm())
                {
                    if (apiKeyForm.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new MainForm());
                    }
                }
            }
        }
    }
}