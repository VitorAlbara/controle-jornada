using controle_jornada.Helpers.Web;

namespace controle_jornada.Views.Components.Cards
{
    public partial class TaskCard : UserControl
    {
        public event EventHandler<int> ControleTempoAcionado;

        public TaskCard()
        {
            InitializeComponent();

        }

        public int NumeroTarefa
        {
            get => int.Parse(txtTaskNumber.Text);
            set
            {
                txtTaskNumber.Text = value.ToString();

                if (value > 0)
                {
                    txtTaskNumber.Cursor = Cursors.Hand;
                }
                else
                {
                    txtTaskNumber.Cursor = Cursors.Default;
                }
            }
        }

        public string TituloTarefa
        {
            get => txtTitle.Text;
            set => txtTitle.Text = value;
        }

        public string TarefaTamanho
        {
            get => txtSize.Text;
            set => txtSize.Text = value;
        }

        public string TemporizadorTexto
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public void BotoesControle(bool ativo)
        {
            btnTimerControl.Enabled = ativo;
        }

        private void btnTimerControl_Click(object sender, EventArgs e)
        {
            ControleTempoAcionado?.Invoke(this, NumeroTarefa);
        }

        private void txtTaskNumber_Click(object sender, EventArgs e)
        {
            RedmineWeb.AbrirTarefaNoNavegador(NumeroTarefa);
        }
    }
}
