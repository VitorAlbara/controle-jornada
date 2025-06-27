using controle_jornada.Models;
using controle_jornada.Repositories;
using controle_jornada.Enums;
using controle_jornada.Properties;
using controle_jornada.Helpers.Web;

namespace controle_jornada.Views.Components.Forms
{
    public partial class TimeControlForm : Form
    {
        private Tarefa _tarefa;
        private TimeSpan _duracaoAtual = TimeSpan.Zero;
        private TimeSpan _tempoRestante = TimeSpan.Zero;
        private System.Windows.Forms.Timer _temporizador;

        private NotifyIcon _iconeBandeja;
        private ContextMenuStrip _menuBandeja;

        public TimeControlForm(Tarefa tarefa)
        {
            InitializeComponent();
            InicializarBandeja();
            PosicaoFormInferiorDireito();

            _tarefa = tarefa;

            txtTaskNumber.Text = _tarefa.Id.ToString();
            txtTitle.Text = _tarefa.Titulo;

            _temporizador = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };

            _temporizador.Tick += Timer_Tick;

            if (tarefa.Id > 0)
                txtTaskNumber.Cursor = Cursors.Hand;

            CarregarDadosTarefa();
        }

        private async void CarregarDadosTarefa()
        {
            var entradaRepo = new EntradaRepo();
            var entradaLocalRepo = new EntradaLocalRepo();

            var tempoRedmine = await entradaRepo.PegarTotalTempoTarefa(_tarefa.Id, DateOnly.FromDateTime(DateTime.Now));
            var tempoLocal = await entradaLocalRepo.PegarTotalTempoTarefa(_tarefa.Id, DateOnly.FromDateTime(DateTime.Now));

            var totalTempoGasto = await entradaRepo.PegarTotalTempoGastoTarefa(_tarefa.Id);

            _duracaoAtual = TimeSpan.FromSeconds(tempoRedmine + tempoLocal);

            txtDuration.Text = _duracaoAtual.ToString(@"hh\:mm:ss");

            if (_tarefa.Tamanho == TamanhoE.G)
                _tempoRestante = TimeSpan.FromHours(6) - TimeSpan.FromSeconds(totalTempoGasto);
            else if (_tarefa.Tamanho == TamanhoE.M)
                _tempoRestante = TimeSpan.FromHours(3) - TimeSpan.FromSeconds(totalTempoGasto);
            else if (_tarefa.Tamanho == TamanhoE.P)
                _tempoRestante = TimeSpan.FromHours(1) - TimeSpan.FromSeconds(totalTempoGasto);

            if (_tempoRestante < TimeSpan.Zero)
                _tempoRestante = TimeSpan.FromHours(0);

            txtRemainingTime.Text = _tempoRestante.ToString(@"hh\:mm\:ss");

            Play();
        }

        private void InicializarBandeja()
        {
            _menuBandeja = new ContextMenuStrip();
            _menuBandeja.Items.Add("Abrir", null, (s, e) => MostrarForm());

            _iconeBandeja = new NotifyIcon
            {
                Icon = Resources.icon_logo,
                ContextMenuStrip = _menuBandeja,
                Text = "Controle de Tempo",
                Visible = true
            };

            _iconeBandeja.DoubleClick += (s, e) => MostrarForm();
        }

        private void MostrarForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void PosicaoFormInferiorDireito()
        {
            var tela = Screen.PrimaryScreen.WorkingArea;

            int x = tela.Width - Width;
            int y = tela.Height - Height;

            StartPosition = FormStartPosition.Manual;
            Location = new Point(x, y);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _duracaoAtual = _duracaoAtual.Add(TimeSpan.FromSeconds(1));
            txtDuration.Text = _duracaoAtual.ToString(@"hh\:mm\:ss");

            if (_tempoRestante > TimeSpan.Zero)
            {
                _tempoRestante = _tempoRestante.Subtract(TimeSpan.FromSeconds(1));
                txtRemainingTime.Text = _tempoRestante.ToString(@"hh\:mm\:ss");
            }
        }

        private void Play()
        {
            _temporizador.Start();

            btnPause.Image = Resources.icon_pause;
            btnPause.Enabled = true;

            btnPlay.Image = Resources.icon_play_s;
            btnPlay.Enabled = false;
        }

        private void Pause()
        {
            _temporizador.Stop();

            btnPause.Image = Resources.icon_pause_s;
            btnPause.Enabled = false;

            btnPlay.Image = Resources.icon_play;
            btnPlay.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private async void btnHome_Click(object sender, EventArgs e)
        {
            _temporizador.Stop();

            var entradaRepo = new EntradaRepo();
            var entradaLocalRepo = new EntradaLocalRepo();
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);

            int tempoRedmine = await entradaRepo.PegarTotalTempoTarefa(_tarefa.Id, dataAtual);
            int totalSegundosLancados = tempoRedmine;

            int segundosRelogio = (int)_duracaoAtual.TotalSeconds;

            int segundosPendentes = segundosRelogio - totalSegundosLancados;

            if (segundosPendentes > 0)
            {
                var novaEntrada = new EntradaLocal
                {
                    TarefaId = _tarefa.Id,
                    TarefaUsuarioId = _tarefa.UsuarioId,
                    DataEntrada = dataAtual,
                    Duracao = segundosPendentes,
                };

                await entradaLocalRepo.AdicionarOuAtualizar(novaEntrada);
            }

            _iconeBandeja.Visible = false;

            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm == null)
            {
                mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                await mainForm.CarregarTarefas();
                mainForm.Show();
                mainForm.WindowState = FormWindowState.Normal;
            }

            Hide();
        }

        private void TimeControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

                return;
            }
            base.OnFormClosing(e);
        }

        private void txtTaskNumber_Click(object sender, EventArgs e)
        {
            if (_tarefa.Id > 0)
                RedmineWeb.AbrirTarefaNoNavegador(_tarefa.Id);
        }
    }
}
