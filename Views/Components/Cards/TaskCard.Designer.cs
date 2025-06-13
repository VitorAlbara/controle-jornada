namespace controle_jornada.Views.Components.Cards
{
    partial class TaskCard
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskCard));
            pnlTask = new Panel();
            txtTaskNumber = new Label();
            pnlTime = new Panel();
            label1 = new Label();
            txtTitle = new Label();
            txtSize = new Label();
            btnTimerControl = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            pnlTask.SuspendLayout();
            pnlTime.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTask
            // 
            pnlTask.BackColor = Color.FromArgb(28, 23, 23);
            pnlTask.BackgroundImageLayout = ImageLayout.None;
            pnlTask.Controls.Add(txtTaskNumber);
            pnlTask.Dock = DockStyle.Top;
            pnlTask.Location = new Point(0, 0);
            pnlTask.Name = "pnlTask";
            pnlTask.Size = new Size(192, 41);
            pnlTask.TabIndex = 0;
            // 
            // txtTaskNumber
            // 
            txtTaskNumber.Dock = DockStyle.Fill;
            txtTaskNumber.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtTaskNumber.ForeColor = Color.White;
            txtTaskNumber.Location = new Point(0, 0);
            txtTaskNumber.Name = "txtTaskNumber";
            txtTaskNumber.Size = new Size(192, 41);
            txtTaskNumber.TabIndex = 0;
            txtTaskNumber.Text = "000000";
            txtTaskNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTime
            // 
            pnlTime.BackColor = Color.FromArgb(28, 23, 23);
            pnlTime.BackgroundImageLayout = ImageLayout.None;
            pnlTime.Controls.Add(label1);
            pnlTime.Dock = DockStyle.Top;
            pnlTime.Location = new Point(0, 0);
            pnlTime.Name = "pnlTime";
            pnlTime.Size = new Size(271, 74);
            pnlTime.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(271, 74);
            label1.TabIndex = 1;
            label1.Text = "00:00:00";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTitle
            // 
            txtTitle.Dock = DockStyle.Top;
            txtTitle.ForeColor = Color.White;
            txtTitle.Location = new Point(0, 51);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(192, 56);
            txtTitle.TabIndex = 2;
            txtTitle.Text = "Esse é um exemplo do título tal do tal pro tal";
            // 
            // txtSize
            // 
            txtSize.Dock = DockStyle.Top;
            txtSize.ForeColor = Color.White;
            txtSize.Location = new Point(0, 117);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(192, 19);
            txtSize.TabIndex = 3;
            txtSize.Text = "Tamanho: G";
            // 
            // btnTimerControl
            // 
            btnTimerControl.BackgroundImage = (Image)resources.GetObject("btnTimerControl.BackgroundImage");
            btnTimerControl.BackgroundImageLayout = ImageLayout.Stretch;
            btnTimerControl.Dock = DockStyle.Right;
            btnTimerControl.FlatStyle = FlatStyle.Flat;
            btnTimerControl.Location = new Point(227, 0);
            btnTimerControl.Name = "btnTimerControl";
            btnTimerControl.Size = new Size(44, 41);
            btnTimerControl.TabIndex = 4;
            btnTimerControl.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(46, 188);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(46, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(540, 38);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtSize);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(txtTitle);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(pnlTask);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(46, 38);
            panel3.Name = "panel3";
            panel3.Size = new Size(192, 150);
            panel3.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 107);
            panel5.Name = "panel5";
            panel5.Size = new Size(192, 10);
            panel5.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 41);
            panel4.Name = "panel4";
            panel4.Size = new Size(192, 10);
            panel4.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(547, 38);
            panel6.Name = "panel6";
            panel6.Size = new Size(39, 150);
            panel6.TabIndex = 8;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(238, 38);
            panel7.Name = "panel7";
            panel7.Size = new Size(38, 150);
            panel7.TabIndex = 9;
            // 
            // panel8
            // 
            panel8.Controls.Add(pnlTime);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(276, 38);
            panel8.Name = "panel8";
            panel8.Size = new Size(271, 94);
            panel8.TabIndex = 10;
            // 
            // panel9
            // 
            panel9.Controls.Add(btnTimerControl);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(276, 132);
            panel9.Name = "panel9";
            panel9.Size = new Size(271, 41);
            panel9.TabIndex = 11;
            // 
            // TaskCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(45, 45, 45);
            Name = "TaskCard";
            Size = new Size(586, 188);
            pnlTask.ResumeLayout(false);
            pnlTime.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTask;
        private Label txtTaskNumber;
        private Panel pnlTime;
        private Label txtTitle;
        private Label txtSize;
        private Label label1;
        private Button btnTimerControl;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private Panel panel4;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
    }
}
