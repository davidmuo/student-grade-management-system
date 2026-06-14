namespace StudentGradeManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem loadMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitMenuItem;

        private GroupBox grpInput;
        private Label lblName;
        private TextBox txtName;
        private Label lblGrade;
        private TextBox txtGrade;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnRemove;

        private GroupBox grpActions;
        private Label lblSearch;
        private TextBox txtSearchName;
        private Button btnSearch;
        private Button btnAverage;
        private Button btnMinMax;

        private DataGridView dgvStudents;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colGrade;
        private DataGridViewTextBoxColumn colCategory;

        private TextBox txtOutput;
        private Label lblOutput;

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            loadMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitMenuItem = new ToolStripMenuItem();

            grpInput = new GroupBox();
            lblName = new Label();
            txtName = new TextBox();
            lblGrade = new Label();
            txtGrade = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnRemove = new Button();

            grpActions = new GroupBox();
            lblSearch = new Label();
            txtSearchName = new TextBox();
            btnSearch = new Button();
            btnAverage = new Button();
            btnMinMax = new Button();

            dgvStudents = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();

            lblOutput = new Label();
            txtOutput = new TextBox();

            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            menuStrip1.SuspendLayout();
            grpInput.SuspendLayout();
            grpActions.SuspendLayout();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);

            // fileMenuItem
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveMenuItem, loadMenuItem, toolStripSeparator1, exitMenuItem });
            fileMenuItem.Text = "&File";

            // saveMenuItem
            saveMenuItem.Text = "&Save to File...";
            saveMenuItem.Click += new EventHandler(SaveMenuItem_Click);

            // loadMenuItem
            loadMenuItem.Text = "&Load from File...";
            loadMenuItem.Click += new EventHandler(LoadMenuItem_Click);

            // exitMenuItem
            exitMenuItem.Text = "E&xit";
            exitMenuItem.Click += new EventHandler(ExitMenuItem_Click);

            // grpInput
            grpInput.Controls.Add(lblName);
            grpInput.Controls.Add(txtName);
            grpInput.Controls.Add(lblGrade);
            grpInput.Controls.Add(txtGrade);
            grpInput.Controls.Add(btnAdd);
            grpInput.Controls.Add(btnUpdate);
            grpInput.Controls.Add(btnRemove);
            grpInput.Location = new Point(12, 30);
            grpInput.Size = new Size(860, 90);
            grpInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInput.Text = "Add / Update Student";

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new Point(15, 35);
            lblName.Text = "Student Name:";

            // txtName
            txtName.Location = new Point(140, 32);
            txtName.Size = new Size(195, 23);

            // lblGrade
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(355, 35);
            lblGrade.Text = "Grade (0-100):";

            // txtGrade
            txtGrade.Location = new Point(475, 32);
            txtGrade.Size = new Size(60, 23);
            txtGrade.KeyDown += new KeyEventHandler(TxtGrade_KeyDown);

            // btnAdd
            btnAdd.Location = new Point(555, 31);
            btnAdd.Size = new Size(95, 27);
            btnAdd.Text = "Add Student";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += new EventHandler(BtnAdd_Click);

            // btnUpdate
            btnUpdate.Location = new Point(656, 31);
            btnUpdate.Size = new Size(95, 27);
            btnUpdate.Text = "Update Grade";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += new EventHandler(BtnUpdate_Click);

            // btnRemove
            btnRemove.Location = new Point(757, 31);
            btnRemove.Size = new Size(90, 27);
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += new EventHandler(BtnRemove_Click);

            // grpActions
            grpActions.Controls.Add(lblSearch);
            grpActions.Controls.Add(txtSearchName);
            grpActions.Controls.Add(btnSearch);
            grpActions.Controls.Add(btnAverage);
            grpActions.Controls.Add(btnMinMax);
            grpActions.Location = new Point(12, 128);
            grpActions.Size = new Size(860, 70);
            grpActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpActions.Text = "Search && Statistics";

            // lblSearch
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(15, 33);
            lblSearch.Text = "Student Name:";

            // txtSearchName
            txtSearchName.Location = new Point(140, 30);
            txtSearchName.Size = new Size(195, 23);
            txtSearchName.KeyDown += new KeyEventHandler(TxtSearchName_KeyDown);

            // btnSearch
            btnSearch.Location = new Point(355, 29);
            btnSearch.Size = new Size(110, 27);
            btnSearch.Text = "Search Grade";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += new EventHandler(BtnSearch_Click);

            // btnAverage
            btnAverage.Location = new Point(475, 29);
            btnAverage.Size = new Size(140, 27);
            btnAverage.Text = "Calculate Average";
            btnAverage.UseVisualStyleBackColor = true;
            btnAverage.Click += new EventHandler(BtnAverage_Click);

            // btnMinMax
            btnMinMax.Location = new Point(625, 29);
            btnMinMax.Size = new Size(180, 27);
            btnMinMax.Text = "Highest / Lowest Grade";
            btnMinMax.UseVisualStyleBackColor = true;
            btnMinMax.Click += new EventHandler(BtnMinMax_Click);

            // dgvStudents
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudents.ReadOnly = true;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { colName, colGrade, colCategory });
            dgvStudents.Location = new Point(12, 204);
            dgvStudents.Size = new Size(860, 270);
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // colName
            colName.HeaderText = "Student Name";
            colName.Name = "colName";

            // colGrade
            colGrade.HeaderText = "Grade";
            colGrade.Name = "colGrade";

            // colCategory
            colCategory.HeaderText = "Category";
            colCategory.Name = "colCategory";

            // lblOutput
            lblOutput.AutoSize = true;
            lblOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblOutput.Location = new Point(12, 482);
            lblOutput.Text = "Messages:";

            // txtOutput
            txtOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutput.Location = new Point(12, 502);
            txtOutput.Size = new Size(860, 110);
            txtOutput.Multiline = true;
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;

            // MainForm
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 624);
            Controls.Add(grpInput);
            Controls.Add(grpActions);
            Controls.Add(dgvStudents);
            Controls.Add(lblOutput);
            Controls.Add(txtOutput);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(700, 500);
            Text = "Student Grade Management System";

            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            menuStrip1.ResumeLayout(false);
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            grpActions.ResumeLayout(false);
            grpActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
