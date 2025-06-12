using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace journey_control.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pnlHeader = new Panel();
            panel10 = new Panel();
            btnAddTask = new Button();
            panel9 = new Panel();
            panel8 = new Panel();
            btnRefreshTasks = new Button();
            panel11 = new Panel();
            panel7 = new Panel();
            panel6 = new Panel();
            btnCalendar = new Button();
            btnNext = new Button();
            lblDate = new Label();
            btnPrev = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            txtTaskSearch = new TextBox();
            panel4 = new Panel();
            pictureBox2 = new PictureBox();
            panel5 = new Panel();
            txtName = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            pnlFooter = new Panel();
            panel12 = new Panel();
            panel22 = new Panel();
            btnReleaseTasks = new Button();
            txtAppVersion = new Label();
            panel14 = new Panel();
            panel17 = new Panel();
            label6 = new Label();
            panel19 = new Panel();
            txtStudyTime = new Label();
            panel16 = new Panel();
            label5 = new Label();
            panel18 = new Panel();
            txtWorkTime = new Label();
            panel15 = new Panel();
            label4 = new Label();
            pnlTime = new Panel();
            txtTotalTime = new Label();
            panel20 = new Panel();
            panel24 = new Panel();
            label7 = new Label();
            panel26 = new Panel();
            txtBeggingTime = new Label();
            panel23 = new Panel();
            label2 = new Label();
            panel25 = new Panel();
            txtReleasedTime = new Label();
            panel21 = new Panel();
            panel13 = new Panel();
            pnlTaskList = new FlowLayoutPanel();
            pnlPaddingL = new Panel();
            pnlPaddingR = new Panel();
            pnlLoading = new Components.Panels.TransparentPanel();
            pictureBox3 = new PictureBox();
            pnlHeader.SuspendLayout();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlFooter.SuspendLayout();
            panel12.SuspendLayout();
            panel22.SuspendLayout();
            panel14.SuspendLayout();
            panel17.SuspendLayout();
            panel19.SuspendLayout();
            panel16.SuspendLayout();
            panel18.SuspendLayout();
            panel15.SuspendLayout();
            pnlTime.SuspendLayout();
            panel20.SuspendLayout();
            panel24.SuspendLayout();
            panel26.SuspendLayout();
            panel23.SuspendLayout();
            panel25.SuspendLayout();
            pnlLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(panel10);
            pnlHeader.Controls.Add(panel9);
            pnlHeader.Controls.Add(panel8);
            pnlHeader.Controls.Add(panel11);
            pnlHeader.Controls.Add(panel7);
            pnlHeader.Controls.Add(panel6);
            pnlHeader.Controls.Add(panel2);
            pnlHeader.Controls.Add(panel3);
            pnlHeader.Controls.Add(panel5);
            pnlHeader.Controls.Add(txtName);
            pnlHeader.Controls.Add(pictureBox1);
            pnlHeader.Controls.Add(panel1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1212, 90);
            pnlHeader.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnAddTask);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(797, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(182, 90);
            panel10.TabIndex = 9;
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.Transparent;
            btnAddTask.Cursor = Cursors.Hand;
            btnAddTask.Dock = DockStyle.Fill;
            btnAddTask.FlatAppearance.BorderSize = 0;
            btnAddTask.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnAddTask.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.ForeColor = Color.FromArgb(218, 218, 218);
            btnAddTask.Image = Properties.Resources.Resources.icon_add;
            btnAddTask.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddTask.Location = new Point(0, 0);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(182, 90);
            btnAddTask.TabIndex = 6;
            btnAddTask.Text = "   Adicionar Tarefa";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(979, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(22, 90);
            panel9.TabIndex = 8;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnRefreshTasks);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(1001, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(182, 90);
            panel8.TabIndex = 7;
            // 
            // btnRefreshTasks
            // 
            btnRefreshTasks.BackColor = Color.Transparent;
            btnRefreshTasks.Cursor = Cursors.Hand;
            btnRefreshTasks.Dock = DockStyle.Fill;
            btnRefreshTasks.FlatAppearance.BorderSize = 0;
            btnRefreshTasks.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnRefreshTasks.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRefreshTasks.FlatStyle = FlatStyle.Flat;
            btnRefreshTasks.ForeColor = Color.FromArgb(218, 218, 218);
            btnRefreshTasks.Image = Properties.Resources.Resources.icon_refresh;
            btnRefreshTasks.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshTasks.Location = new Point(0, 0);
            btnRefreshTasks.Name = "btnRefreshTasks";
            btnRefreshTasks.Size = new Size(182, 90);
            btnRefreshTasks.TabIndex = 7;
            btnRefreshTasks.Text = "   Atualizar Tarefas";
            btnRefreshTasks.UseVisualStyleBackColor = false;
            btnRefreshTasks.Click += btnRefreshTasks_Click;
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Right;
            panel11.Location = new Point(1183, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(29, 90);
            panel11.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(685, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(22, 90);
            panel7.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnCalendar);
            panel6.Controls.Add(btnNext);
            panel6.Controls.Add(lblDate);
            panel6.Controls.Add(btnPrev);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(464, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(221, 90);
            panel6.TabIndex = 4;
            // 
            // btnCalendar
            // 
            btnCalendar.BackColor = Color.Transparent;
            btnCalendar.Cursor = Cursors.Hand;
            btnCalendar.FlatAppearance.BorderSize = 0;
            btnCalendar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCalendar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCalendar.FlatStyle = FlatStyle.Flat;
            btnCalendar.Image = Properties.Resources.Resources.icon_calendar;
            btnCalendar.Location = new Point(144, 27);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Size = new Size(40, 40);
            btnCalendar.TabIndex = 5;
            btnCalendar.UseVisualStyleBackColor = false;
            btnCalendar.Click += btnCalendar_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNext.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Image = Properties.Resources.Resources.icon_next;
            btnNext.Location = new Point(178, 29);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(40, 40);
            btnNext.TabIndex = 4;
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDate.ForeColor = Color.FromArgb(218, 218, 218);
            lblDate.Location = new Point(32, 6);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(118, 82);
            lblDate.TabIndex = 3;
            lblDate.Text = "00/00/0000";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.Transparent;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPrev.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Image = Properties.Resources.Resources.icon_prev;
            btnPrev.Location = new Point(0, 29);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(40, 40);
            btnPrev.TabIndex = 0;
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(442, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(22, 90);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtTaskSearch);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(pictureBox2);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(258, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(184, 90);
            panel3.TabIndex = 4;
            // 
            // txtTaskSearch
            // 
            txtTaskSearch.BackColor = Color.FromArgb(28, 23, 23);
            txtTaskSearch.BorderStyle = BorderStyle.None;
            txtTaskSearch.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            txtTaskSearch.ForeColor = Color.FromArgb(218, 218, 218);
            txtTaskSearch.Location = new Point(53, 29);
            txtTaskSearch.MaxLength = 7;
            txtTaskSearch.Name = "txtTaskSearch";
            txtTaskSearch.Size = new Size(117, 36);
            txtTaskSearch.TabIndex = 5;
            txtTaskSearch.TextChanged += txtTaskSearch_TextChanged;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(218, 218, 218);
            panel4.Location = new Point(53, 68);
            panel4.Name = "panel4";
            panel4.Size = new Size(117, 2);
            panel4.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox2.Image = Properties.Resources.Resources.icon_search;
            pictureBox2.Location = new Point(0, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(236, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(22, 90);
            panel5.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Left;
            txtName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtName.ForeColor = Color.FromArgb(218, 218, 218);
            txtName.Location = new Point(109, 0);
            txtName.Name = "txtName";
            txtName.Size = new Size(127, 90);
            txtName.TabIndex = 2;
            txtName.Text = "Nome";
            txtName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.Resources.icon_user;
            pictureBox1.Location = new Point(58, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(58, 90);
            panel1.TabIndex = 1;
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(panel12);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 556);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1212, 133);
            pnlFooter.TabIndex = 1;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(39, 39, 39);
            panel12.Controls.Add(panel22);
            panel12.Controls.Add(panel14);
            panel12.Controls.Add(panel20);
            panel12.Controls.Add(panel21);
            panel12.Controls.Add(panel13);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(1212, 133);
            panel12.TabIndex = 0;
            // 
            // panel22
            // 
            panel22.Controls.Add(btnReleaseTasks);
            panel22.Controls.Add(txtAppVersion);
            panel22.Dock = DockStyle.Fill;
            panel22.Location = new Point(844, 0);
            panel22.Name = "panel22";
            panel22.Size = new Size(351, 133);
            panel22.TabIndex = 4;
            // 
            // btnReleaseTasks
            // 
            btnReleaseTasks.BackColor = Color.FromArgb(28, 23, 23);
            btnReleaseTasks.Cursor = Cursors.Hand;
            btnReleaseTasks.FlatAppearance.BorderSize = 0;
            btnReleaseTasks.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 23, 23);
            btnReleaseTasks.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 23, 23);
            btnReleaseTasks.FlatStyle = FlatStyle.Flat;
            btnReleaseTasks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReleaseTasks.ForeColor = Color.FromArgb(218, 218, 218);
            btnReleaseTasks.ImageAlign = ContentAlignment.MiddleLeft;
            btnReleaseTasks.Location = new Point(84, 31);
            btnReleaseTasks.Name = "btnReleaseTasks";
            btnReleaseTasks.Size = new Size(154, 78);
            btnReleaseTasks.TabIndex = 7;
            btnReleaseTasks.Text = "Lançar Tempo";
            btnReleaseTasks.UseVisualStyleBackColor = false;
            btnReleaseTasks.Click += btnReleaseTasks_Click;
            // 
            // txtAppVersion
            // 
            txtAppVersion.Font = new Font("Segoe UI", 8F);
            txtAppVersion.ForeColor = Color.Gray;
            txtAppVersion.Location = new Point(212, 104);
            txtAppVersion.Name = "txtAppVersion";
            txtAppVersion.Size = new Size(139, 22);
            txtAppVersion.TabIndex = 8;
            txtAppVersion.Text = "0.0.0.0";
            txtAppVersion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel14
            // 
            panel14.Controls.Add(panel17);
            panel14.Controls.Add(panel16);
            panel14.Controls.Add(panel15);
            panel14.Dock = DockStyle.Left;
            panel14.Location = new Point(221, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(623, 133);
            panel14.TabIndex = 1;
            // 
            // panel17
            // 
            panel17.Controls.Add(label6);
            panel17.Controls.Add(panel19);
            panel17.Dock = DockStyle.Left;
            panel17.Location = new Point(414, 0);
            panel17.Name = "panel17";
            panel17.Size = new Size(207, 133);
            panel17.TabIndex = 2;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.FromArgb(218, 218, 218);
            label6.Location = new Point(9, 17);
            label6.Name = "label6";
            label6.Size = new Size(117, 22);
            label6.TabIndex = 5;
            label6.Text = "Total Estudo";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel19
            // 
            panel19.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel19.BackColor = Color.FromArgb(28, 23, 23);
            panel19.BackgroundImageLayout = ImageLayout.None;
            panel19.Controls.Add(txtStudyTime);
            panel19.Location = new Point(9, 42);
            panel19.Name = "panel19";
            panel19.Size = new Size(188, 61);
            panel19.TabIndex = 3;
            // 
            // txtStudyTime
            // 
            txtStudyTime.Dock = DockStyle.Fill;
            txtStudyTime.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txtStudyTime.ForeColor = Color.White;
            txtStudyTime.Location = new Point(0, 0);
            txtStudyTime.Name = "txtStudyTime";
            txtStudyTime.Size = new Size(188, 61);
            txtStudyTime.TabIndex = 1;
            txtStudyTime.Text = "00:00:00";
            txtStudyTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel16
            // 
            panel16.Controls.Add(label5);
            panel16.Controls.Add(panel18);
            panel16.Dock = DockStyle.Left;
            panel16.Location = new Point(207, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(207, 133);
            panel16.TabIndex = 1;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(218, 218, 218);
            label5.Location = new Point(9, 17);
            label5.Name = "label5";
            label5.Size = new Size(117, 22);
            label5.TabIndex = 4;
            label5.Text = "Total Trabalhado";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel18
            // 
            panel18.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel18.BackColor = Color.FromArgb(28, 23, 23);
            panel18.BackgroundImageLayout = ImageLayout.None;
            panel18.Controls.Add(txtWorkTime);
            panel18.Location = new Point(9, 42);
            panel18.Name = "panel18";
            panel18.Size = new Size(188, 61);
            panel18.TabIndex = 3;
            // 
            // txtWorkTime
            // 
            txtWorkTime.Dock = DockStyle.Fill;
            txtWorkTime.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txtWorkTime.ForeColor = Color.White;
            txtWorkTime.Location = new Point(0, 0);
            txtWorkTime.Name = "txtWorkTime";
            txtWorkTime.Size = new Size(188, 61);
            txtWorkTime.TabIndex = 1;
            txtWorkTime.Text = "00:00:00";
            txtWorkTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            panel15.Controls.Add(label4);
            panel15.Controls.Add(pnlTime);
            panel15.Dock = DockStyle.Left;
            panel15.Location = new Point(0, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(207, 133);
            panel15.TabIndex = 0;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(218, 218, 218);
            label4.Location = new Point(9, 17);
            label4.Name = "label4";
            label4.Size = new Size(117, 22);
            label4.TabIndex = 3;
            label4.Text = "Tempo Total";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTime
            // 
            pnlTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTime.BackColor = Color.FromArgb(28, 23, 23);
            pnlTime.BackgroundImageLayout = ImageLayout.None;
            pnlTime.Controls.Add(txtTotalTime);
            pnlTime.Location = new Point(9, 42);
            pnlTime.Name = "pnlTime";
            pnlTime.Size = new Size(188, 61);
            pnlTime.TabIndex = 2;
            // 
            // txtTotalTime
            // 
            txtTotalTime.Dock = DockStyle.Fill;
            txtTotalTime.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txtTotalTime.ForeColor = Color.White;
            txtTotalTime.Location = new Point(0, 0);
            txtTotalTime.Name = "txtTotalTime";
            txtTotalTime.Size = new Size(188, 61);
            txtTotalTime.TabIndex = 1;
            txtTotalTime.Text = "00:00:00";
            txtTotalTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel20
            // 
            panel20.Controls.Add(panel24);
            panel20.Controls.Add(panel23);
            panel20.Dock = DockStyle.Left;
            panel20.Location = new Point(70, 0);
            panel20.Name = "panel20";
            panel20.Size = new Size(151, 133);
            panel20.TabIndex = 2;
            // 
            // panel24
            // 
            panel24.Controls.Add(label7);
            panel24.Controls.Add(panel26);
            panel24.Dock = DockStyle.Bottom;
            panel24.Location = new Point(0, 66);
            panel24.Name = "panel24";
            panel24.Size = new Size(151, 67);
            panel24.TabIndex = 1;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 8F);
            label7.ForeColor = Color.FromArgb(218, 218, 218);
            label7.Location = new Point(12, -3);
            label7.Name = "label7";
            label7.Size = new Size(117, 22);
            label7.TabIndex = 7;
            label7.Text = "Tempo Pendente";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel26
            // 
            panel26.Anchor = AnchorStyles.Left;
            panel26.BackColor = Color.FromArgb(28, 23, 23);
            panel26.BackgroundImageLayout = ImageLayout.None;
            panel26.Controls.Add(txtBeggingTime);
            panel26.Location = new Point(12, 22);
            panel26.Name = "panel26";
            panel26.Size = new Size(123, 29);
            panel26.TabIndex = 5;
            // 
            // txtBeggingTime
            // 
            txtBeggingTime.Dock = DockStyle.Fill;
            txtBeggingTime.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtBeggingTime.ForeColor = Color.White;
            txtBeggingTime.Location = new Point(0, 0);
            txtBeggingTime.Name = "txtBeggingTime";
            txtBeggingTime.Size = new Size(123, 29);
            txtBeggingTime.TabIndex = 1;
            txtBeggingTime.Text = "00:00:00";
            txtBeggingTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel23
            // 
            panel23.Controls.Add(label2);
            panel23.Controls.Add(panel25);
            panel23.Dock = DockStyle.Top;
            panel23.Location = new Point(0, 0);
            panel23.Name = "panel23";
            panel23.Size = new Size(151, 68);
            panel23.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 8F);
            label2.ForeColor = Color.FromArgb(218, 218, 218);
            label2.Location = new Point(12, 3);
            label2.Name = "label2";
            label2.Size = new Size(117, 22);
            label2.TabIndex = 6;
            label2.Text = "Tempo Lançado";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel25
            // 
            panel25.Anchor = AnchorStyles.Left;
            panel25.BackColor = Color.FromArgb(28, 23, 23);
            panel25.BackgroundImageLayout = ImageLayout.None;
            panel25.Controls.Add(txtReleasedTime);
            panel25.Location = new Point(12, 29);
            panel25.Name = "panel25";
            panel25.Size = new Size(123, 29);
            panel25.TabIndex = 4;
            // 
            // txtReleasedTime
            // 
            txtReleasedTime.Anchor = AnchorStyles.None;
            txtReleasedTime.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtReleasedTime.ForeColor = Color.White;
            txtReleasedTime.Location = new Point(0, 0);
            txtReleasedTime.Name = "txtReleasedTime";
            txtReleasedTime.Size = new Size(123, 29);
            txtReleasedTime.TabIndex = 1;
            txtReleasedTime.Text = "00:00:00";
            txtReleasedTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel21
            // 
            panel21.Dock = DockStyle.Right;
            panel21.Location = new Point(1195, 0);
            panel21.Name = "panel21";
            panel21.Size = new Size(17, 133);
            panel21.TabIndex = 3;
            // 
            // panel13
            // 
            panel13.Dock = DockStyle.Left;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(70, 133);
            panel13.TabIndex = 0;
            // 
            // pnlTaskList
            // 
            pnlTaskList.AutoScroll = true;
            pnlTaskList.Dock = DockStyle.Fill;
            pnlTaskList.Location = new Point(70, 90);
            pnlTaskList.Name = "pnlTaskList";
            pnlTaskList.Size = new Size(1078, 466);
            pnlTaskList.TabIndex = 3;
            pnlTaskList.Resize += pnlTaskList_Resize;
            // 
            // pnlPaddingL
            // 
            pnlPaddingL.Dock = DockStyle.Left;
            pnlPaddingL.Location = new Point(0, 90);
            pnlPaddingL.Name = "pnlPaddingL";
            pnlPaddingL.Size = new Size(70, 466);
            pnlPaddingL.TabIndex = 0;
            // 
            // pnlPaddingR
            // 
            pnlPaddingR.Dock = DockStyle.Right;
            pnlPaddingR.Location = new Point(1148, 90);
            pnlPaddingR.Name = "pnlPaddingR";
            pnlPaddingR.Size = new Size(64, 466);
            pnlPaddingR.TabIndex = 1;
            // 
            // pnlLoading
            // 
            pnlLoading.BackColor = Color.Transparent;
            pnlLoading.BackgroundColor = Color.Black;
            pnlLoading.Controls.Add(pictureBox3);
            pnlLoading.Dock = DockStyle.Fill;
            pnlLoading.Location = new Point(70, 90);
            pnlLoading.Name = "pnlLoading";
            pnlLoading.Opacity = 128;
            pnlLoading.Size = new Size(1078, 466);
            pnlLoading.TabIndex = 0;
            pnlLoading.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = Properties.Resources.Resources.icon_loading;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(1078, 466);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 23, 23);
            ClientSize = new Size(1212, 689);
            Controls.Add(pnlLoading);
            Controls.Add(pnlTaskList);
            Controls.Add(pnlPaddingR);
            Controls.Add(pnlPaddingL);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Controle de Jornada";
            pnlHeader.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlFooter.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel22.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel18.ResumeLayout(false);
            panel15.ResumeLayout(false);
            pnlTime.ResumeLayout(false);
            panel20.ResumeLayout(false);
            panel24.ResumeLayout(false);
            panel26.ResumeLayout(false);
            panel23.ResumeLayout(false);
            panel25.ResumeLayout(false);
            pnlLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlFooter;
        private FlowLayoutPanel pnlTaskList;
        private Panel pnlPaddingL;
        private Panel pnlPaddingR;
        private PictureBox pictureBox1;
        private Label txtName;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox2;
        private Panel panel4;
        private TextBox txtTaskSearch;
        private Panel panel6;
        private Panel panel5;
        private Button btnPrev;
        private Label lblDate;
        private Button btnCalendar;
        private Button btnNext;
        private Components.Panels.TransparentPanel pnlLoading;
        private PictureBox pictureBox3;
        private Panel panel10;
        private Panel panel9;
        private Panel panel8;
        private Panel panel11;
        private Panel panel7;
        private Button btnAddTask;
        private Button btnRefreshTasks;
        private Panel panel12;
        private Panel panel14;
        private Panel panel17;
        private Panel panel16;
        private Panel panel15;
        private Panel panel13;
        private Panel panel19;
        private Label txtStudyTime;
        private Panel panel18;
        private Label txtWorkTime;
        private Panel pnlTime;
        private Label txtTotalTime;
        private Label label6;
        private Label label5;
        private Label label4;
        private Panel panel21;
        private Panel panel20;
        private Panel panel22;
        private Panel panel24;
        private Label label7;
        private Panel panel26;
        private Label txtBeggingTime;
        private Panel panel23;
        private Label label2;
        private Panel panel25;
        private Label txtReleasedTime;
        private Button btnReleaseTasks;
        private Label txtAppVersion;
    }
}