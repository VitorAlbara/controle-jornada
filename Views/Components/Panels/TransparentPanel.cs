namespace controle_jornada.Views.Components.Panels
{
    public class TransparentPanel : Panel
    {
        private int _opacity = 128; // Valor padrão de opacidade (0-255).
        private Color _backgroundColor = Color.Black; // Cor padrão de fundo.

        /// <summary>
        /// Define ou obtém a opacidade do painel (0 totalmente transparente, 255 totalmente opaco).
        /// </summary>
        public int Opacity
        {
            get => _opacity;
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentOutOfRangeException(nameof(Opacity), "O valor deve estar entre 0 e 255.");

                _opacity = value;
                Invalidate(); // Re-desenha o painel.
            }
        }

        /// <summary>
        /// Define ou obtém a cor de fundo do painel.
        /// </summary>
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                Invalidate(); // Re-desenha o painel.
            }
        }

        /// <summary>
        /// Construtor do TransparentPanel.
        /// </summary>
        public TransparentPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Sobrescreve o método de pintura para desenhar o fundo com opacidade.
        /// </summary>
        /// <param name="e">Argumentos do evento de pintura.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.FromArgb(_opacity, _backgroundColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            base.OnPaint(e);
        }
    }
}
