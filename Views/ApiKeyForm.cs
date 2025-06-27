using controle_jornada.Helpers.AppData;
using controle_jornada.Repositories;
using controle_jornada.Services;

namespace controle_jornada.Views
{
    public partial class ApiKeyForm : Form
    {
        private readonly ProjetoRepo _projectRepo = new ProjetoRepo();

        public ApiKeyForm()
        {
            InitializeComponent();

            LoadProjects();
        }

        private async void LoadProjects()
        {
            cmbProject.Items.Clear();
            cmbProject.DataSource = await _projectRepo.GetAll();
            cmbProject.DisplayMember = "Nome";
            cmbProject.ValueMember = "Id";
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                string apiKey = txtApiCode.Text.Trim();

                if (string.IsNullOrEmpty(apiKey))
                    throw new Exception("Por favor, insira o código da API.");

                if (cmbProject.SelectedValue == null)
                    throw new Exception("Por favor, selecione o projeto principal.");

                var redmineService = new RedmineServ();
                var user = await redmineService.PegarUsuario(apiKey);

                if (user == null)
                    throw new Exception("Código da API inválido. Tente novamente.");

                user.ChaveApi = apiKey;
                user.ProjetoId = (int)cmbProject.SelectedValue;

                DadosUsuario.SalvarDadosUsuario(user);
                MessageBox.Show("Código da API validado e salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
