// using statements para o novo projeto
using controle_jornada.Helpers.AppData;
using controle_jornada.Repositories;
using controle_jornada.Services;
using System.Windows.Forms;

// Namespace do novo projeto
namespace controle_jornada.Views
{
    public partial class ApiKeyForm : Form
    {
        private readonly ProjectRepo _projectRepo = new ProjectRepo();

        public ApiKeyForm()
        {
            // Este método é definido no arquivo ApiKeyForm.Designer.cs
            InitializeComponent();
            LoadProjects();
        }

        private async void LoadProjects()
        {
            cmbProject.Items.Clear();
            cmbProject.DataSource = await _projectRepo.GetAll();
            cmbProject.DisplayMember = "Name";
            cmbProject.ValueMember = "Id";
        }

        // Este método é ligado ao botão no arquivo .Designer.cs
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string apiKey = txtApiCode.Text.Trim();

                if (string.IsNullOrEmpty(apiKey))
                    throw new Exception("Por favor, insira o código da API.");

                if (cmbProject.SelectedValue == null)
                    throw new Exception("Por favor, selecione o projeto principal.");

                var redmineService = new RedmineService();
                var user = await redmineService.GetUserAsync(apiKey);

                if (user == null)
                    throw new Exception("Código da API inválido. Tente novamente.");

                user.ApiKey = apiKey;
                user.ProjectId = (int)cmbProject.SelectedValue;

                UserDataManager.SaveUserData(user);
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