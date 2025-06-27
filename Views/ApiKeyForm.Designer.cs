namespace controle_jornada.Views
{
    partial class ApiKeyForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel6 = new Panel();
            panel8 = new Panel();
            btnSave = new Button();
            panel12 = new Panel();
            cmbProject = new ComboBox();
            panel11 = new Panel();
            lblProject = new Label();
            panel9 = new Panel();
            txtApiCode = new TextBox();
            panel7 = new Panel();
            label2 = new Label();
            panel10 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(472, 464);
            panel1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel8);
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(110, 110);
            panel6.Name = "panel6";
            panel6.Size = new Size(252, 244);
            panel6.TabIndex = 4;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnSave);
            panel8.Controls.Add(panel12);
            panel8.Controls.Add(cmbProject);
            panel8.Controls.Add(panel11);
            panel8.Controls.Add(lblProject);
            panel8.Controls.Add(panel9);
            panel8.Controls.Add(txtApiCode);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 84);
            panel8.Name = "panel8";
            panel8.Size = new Size(252, 160);
            panel8.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(45, 45, 45);
            btnSave.Dock = DockStyle.Top;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.ForeColor = SystemColors.ButtonHighlight;
            btnSave.Location = new Point(0, 109);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(252, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 85);
            panel12.Name = "panel12";
            panel12.Size = new Size(252, 24);
            panel12.TabIndex = 6;
            // 
            // cmbProject
            // 
            cmbProject.BackColor = Color.FromArgb(45, 45, 45);
            cmbProject.Dock = DockStyle.Top;
            cmbProject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProject.ForeColor = SystemColors.Info;
            cmbProject.FormattingEnabled = true;
            cmbProject.Location = new Point(0, 62);
            cmbProject.Name = "cmbProject";
            cmbProject.Size = new Size(252, 23);
            cmbProject.TabIndex = 5;
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 52);
            panel11.Name = "panel11";
            panel11.Size = new Size(252, 10);
            panel11.TabIndex = 7;
            // 
            // lblProject
            // 
            lblProject.AutoSize = true;
            lblProject.Dock = DockStyle.Top;
            lblProject.ForeColor = SystemColors.ButtonHighlight;
            lblProject.Location = new Point(0, 37);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(94, 15);
            lblProject.TabIndex = 3;
            lblProject.Text = "Principal Projeto";
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 23);
            panel9.Name = "panel9";
            panel9.Size = new Size(252, 14);
            panel9.TabIndex = 1;
            // 
            // txtApiCode
            // 
            txtApiCode.BackColor = Color.FromArgb(45, 45, 45);
            txtApiCode.BorderStyle = BorderStyle.FixedSingle;
            txtApiCode.Dock = DockStyle.Top;
            txtApiCode.ForeColor = SystemColors.Info;
            txtApiCode.Location = new Point(0, 0);
            txtApiCode.MaxLength = 40;
            txtApiCode.Name = "txtApiCode";
            txtApiCode.Size = new Size(252, 23);
            txtApiCode.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(label2);
            panel7.Controls.Add(panel10);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(252, 84);
            panel7.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(0, 59);
            label2.Name = "label2";
            label2.Size = new Size(150, 15);
            label2.TabIndex = 1;
            label2.Text = "Código da API do Redmine";
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(0, 74);
            panel10.Name = "panel10";
            panel10.Size = new Size(252, 10);
            panel10.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(362, 110);
            panel5.Name = "panel5";
            panel5.Size = new Size(110, 244);
            panel5.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 110);
            panel4.Name = "panel4";
            panel4.Size = new Size(110, 244);
            panel4.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 354);
            panel3.Name = "panel3";
            panel3.Size = new Size(472, 110);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(472, 110);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 56);
            label1.Name = "label1";
            label1.Padding = new Padding(100, 0, 0, 0);
            label1.Size = new Size(382, 54);
            label1.TabIndex = 0;
            label1.Text = "Bem-vindo(a)";
            // 
            // ApiKeyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 23, 23);
            ClientSize = new Size(472, 464);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ApiKeyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Controle de Jornada";
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel8;
        private TextBox txtApiCode;
        private Panel panel7;
        private Button btnSave;
        private Panel panel9;
        private Label label1;
        private Panel panel10;
        private Label label2;
        private Label lblProject;
        private Panel panel12;
        private ComboBox cmbProject;
        private Panel panel11;
    }
}