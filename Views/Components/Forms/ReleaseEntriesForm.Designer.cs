namespace controle_jornada.Views.Components.Forms
{
    partial class ReleaseEntriesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReleaseEntriesForm));
            panel1 = new Panel();
            gridEntries = new DataGridView();
            colOk = new DataGridViewCheckBoxColumn();
            colProject = new DataGridViewComboBoxColumn();
            colTaskNum = new DataGridViewTextBoxColumn();
            colTaskTitle = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colDuration = new DataGridViewTextBoxColumn();
            colComment = new DataGridViewTextBoxColumn();
            colActivity = new DataGridViewComboBoxColumn();
            colProjectInd = new DataGridViewComboBoxColumn();
            colExecPlace = new DataGridViewComboBoxColumn();
            colOvertime = new DataGridViewComboBoxColumn();
            colId = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            txtName = new Label();
            pnlFooter = new Panel();
            panel12 = new Panel();
            btnReady = new Button();
            label1 = new Label();
            pnlTime = new Panel();
            txtQtd = new Label();
            panel21 = new Panel();
            panel13 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridEntries).BeginInit();
            panel2.SuspendLayout();
            pnlFooter.SuspendLayout();
            panel12.SuspendLayout();
            pnlTime.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(gridEntries);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pnlFooter);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1408, 562);
            panel1.TabIndex = 0;
            // 
            // gridEntries
            // 
            gridEntries.AllowUserToAddRows = false;
            gridEntries.AllowUserToDeleteRows = false;
            gridEntries.AllowUserToResizeRows = false;
            gridEntries.BackgroundColor = Color.FromArgb(28, 23, 23);
            gridEntries.BorderStyle = BorderStyle.None;
            gridEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEntries.Columns.AddRange(new DataGridViewColumn[] { colOk, colProject, colTaskNum, colTaskTitle, colDate, colDuration, colComment, colActivity, colProjectInd, colExecPlace, colOvertime, colId });
            gridEntries.Dock = DockStyle.Fill;
            gridEntries.GridColor = Color.FromArgb(28, 23, 23);
            gridEntries.Location = new Point(70, 74);
            gridEntries.Name = "gridEntries";
            gridEntries.Size = new Size(1268, 371);
            gridEntries.TabIndex = 6;
            // 
            // colOk
            // 
            colOk.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colOk.HeaderText = "";
            colOk.Name = "colOk";
            colOk.ReadOnly = true;
            colOk.Width = 5;
            // 
            // colProject
            // 
            colProject.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProject.FillWeight = 50F;
            colProject.HeaderText = "Projeto";
            colProject.Name = "colProject";
            // 
            // colTaskNum
            // 
            colTaskNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTaskNum.HeaderText = "Tarefa";
            colTaskNum.Name = "colTaskNum";
            colTaskNum.ReadOnly = true;
            colTaskNum.Width = 63;
            // 
            // colTaskTitle
            // 
            colTaskTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTaskTitle.HeaderText = "Título";
            colTaskTitle.Name = "colTaskTitle";
            colTaskTitle.ReadOnly = true;
            colTaskTitle.Width = 62;
            // 
            // colDate
            // 
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDate.HeaderText = "Data";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 56;
            // 
            // colDuration
            // 
            colDuration.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDuration.HeaderText = "Tempo Gasto";
            colDuration.Name = "colDuration";
            colDuration.ReadOnly = true;
            colDuration.Width = 93;
            // 
            // colComment
            // 
            colComment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colComment.FillWeight = 150F;
            colComment.HeaderText = "Comentário";
            colComment.Name = "colComment";
            // 
            // colActivity
            // 
            colActivity.AutoComplete = false;
            colActivity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colActivity.HeaderText = "Atividade";
            colActivity.Name = "colActivity";
            // 
            // colProjectInd
            // 
            colProjectInd.AutoComplete = false;
            colProjectInd.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProjectInd.HeaderText = "Indicativo Projeto";
            colProjectInd.Name = "colProjectInd";
            // 
            // colExecPlace
            // 
            colExecPlace.AutoComplete = false;
            colExecPlace.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colExecPlace.HeaderText = "Local de Execução";
            colExecPlace.Name = "colExecPlace";
            colExecPlace.Width = 99;
            // 
            // colOvertime
            // 
            colOvertime.AutoComplete = false;
            colOvertime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colOvertime.HeaderText = "Hora Extra";
            colOvertime.Name = "colOvertime";
            colOvertime.Width = 61;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1338, 74);
            panel4.Name = "panel4";
            panel4.Size = new Size(70, 371);
            panel4.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 74);
            panel3.Name = "panel3";
            panel3.Size = new Size(70, 371);
            panel3.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtName);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1408, 74);
            panel2.TabIndex = 3;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            txtName.ForeColor = Color.FromArgb(218, 218, 218);
            txtName.Location = new Point(70, 9);
            txtName.Name = "txtName";
            txtName.Size = new Size(1302, 65);
            txtName.TabIndex = 3;
            txtName.Text = "Preencha as informações corretamente!";
            txtName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(panel12);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 445);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1408, 117);
            pnlFooter.TabIndex = 2;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(39, 39, 39);
            panel12.Controls.Add(btnReady);
            panel12.Controls.Add(label1);
            panel12.Controls.Add(pnlTime);
            panel12.Controls.Add(panel21);
            panel12.Controls.Add(panel13);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(1408, 117);
            panel12.TabIndex = 0;
            // 
            // btnReady
            // 
            btnReady.BackColor = Color.DarkGreen;
            btnReady.Cursor = Cursors.Hand;
            btnReady.FlatAppearance.BorderSize = 0;
            btnReady.FlatAppearance.MouseDownBackColor = Color.SeaGreen;
            btnReady.FlatAppearance.MouseOverBackColor = Color.SeaGreen;
            btnReady.FlatStyle = FlatStyle.Flat;
            btnReady.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReady.ForeColor = Color.FromArgb(218, 218, 218);
            btnReady.ImageAlign = ContentAlignment.MiddleLeft;
            btnReady.Location = new Point(600, 16);
            btnReady.Name = "btnReady";
            btnReady.Size = new Size(627, 78);
            btnReady.TabIndex = 8;
            btnReady.Text = "Pronto";
            btnReady.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(218, 218, 218);
            label1.Location = new Point(176, 23);
            label1.Name = "label1";
            label1.Size = new Size(166, 65);
            label1.TabIndex = 5;
            label1.Text = "Registros Revisados:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTime
            // 
            pnlTime.BackColor = Color.FromArgb(28, 23, 23);
            pnlTime.BackgroundImageLayout = ImageLayout.None;
            pnlTime.Controls.Add(txtQtd);
            pnlTime.Location = new Point(348, 26);
            pnlTime.Name = "pnlTime";
            pnlTime.Size = new Size(170, 62);
            pnlTime.TabIndex = 4;
            // 
            // txtQtd
            // 
            txtQtd.Dock = DockStyle.Fill;
            txtQtd.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txtQtd.ForeColor = Color.White;
            txtQtd.Location = new Point(0, 0);
            txtQtd.Name = "txtQtd";
            txtQtd.Size = new Size(170, 62);
            txtQtd.TabIndex = 1;
            txtQtd.Text = "00/00";
            txtQtd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel21
            // 
            panel21.Dock = DockStyle.Right;
            panel21.Location = new Point(1338, 0);
            panel21.Name = "panel21";
            panel21.Size = new Size(70, 117);
            panel21.TabIndex = 3;
            // 
            // panel13
            // 
            panel13.Dock = DockStyle.Left;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(70, 117);
            panel13.TabIndex = 0;
            // 
            // ReleaseEntriesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 23, 23);
            ClientSize = new Size(1408, 562);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReleaseEntriesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lançamento de Horas Pendentes";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridEntries).EndInit();
            panel2.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            panel12.ResumeLayout(false);
            pnlTime.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlFooter;
        private Panel panel12;
        private Panel panel21;
        private Panel panel13;
        private Panel panel2;
        private DataGridView gridEntries;
        private Panel panel4;
        private Panel panel3;
        private Label txtName;
        private Label label1;
        private Panel pnlTime;
        private Label txtQtd;
        private DataGridViewCheckBoxColumn colOk;
        private DataGridViewComboBoxColumn colProject;
        private DataGridViewTextBoxColumn colTaskNum;
        private DataGridViewTextBoxColumn colTaskTitle;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colDuration;
        private DataGridViewTextBoxColumn colComment;
        private DataGridViewComboBoxColumn colActivity;
        private DataGridViewComboBoxColumn colProjectInd;
        private DataGridViewComboBoxColumn colExecPlace;
        private DataGridViewComboBoxColumn colOvertime;
        private Button btnReady;
        private DataGridViewTextBoxColumn colId;
    }
}