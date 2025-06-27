namespace controle_jornada.Views.Components.Forms
{
    public partial class InputForm : Form
    {
        public string InputText { get; private set; }
        public string DescrText { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly DueDate { get; private set; }
        public bool isCustom { get; private set; }

        public InputForm()
        {
            InitializeComponent();

            dtStartDate.Enabled = checkCustom.Checked;
            dtDueDate.Enabled = checkCustom.Checked;
        }

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                isCustom = false;
                InputText = txtNum.Text;

                if (InputText == "")
                    throw new Exception("Informe o número da tarefa");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar tarefa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustomOk_Click(object sender, EventArgs e)
        {
            try
            {
                isCustom = true;
                InputText = txtTitle.Text;
                DescrText = txtDescr.Text;
                StartDate = checkCustom.Checked ? DateOnly.FromDateTime(dtStartDate.Value) : DateOnly.MinValue;
                DueDate = checkCustom.Checked ? DateOnly.FromDateTime(dtDueDate.Value) : DateOnly.MaxValue;

                if (InputText == "")
                    throw new Exception("Informe o título");

                if (DescrText == "")
                    throw new Exception("Informe a descrição");

                if (DueDate <= StartDate)
                    throw new Exception("Data final precisa ser maior que a data inicial");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar tarefa: {ex.Message}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnCustomCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void checkCustom_CheckedChanged(object sender, EventArgs e)
        {
            dtStartDate.Enabled = checkCustom.Checked;
            dtDueDate.Enabled = checkCustom.Checked;
        }
    }
}
