namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Main application window for the Student Grade Management System.
    /// Wires up the on-screen UI (buttons, grid, menu) to the GradeManager
    /// business logic, which stores data in a Dictionary&lt;string, int&gt;.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly GradeManager _manager = new();

        public MainForm()
        {
            InitializeComponent();
            dgvStudents.SelectionChanged += DgvStudents_SelectionChanged;
        }

        // ----- Add / Update / Remove -------------------------------------------------

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int grade = ParseGrade(txtGrade.Text);

                _manager.AddStudent(name, grade);
                AppendOutput($"Added student '{name.Trim()}' with grade {grade}.");
                RefreshGrid();
                ClearInputs();
            }
            catch (Exception ex) when (ex is DuplicateStudentException or InvalidGradeException
                                          or ArgumentException or FormatException)
            {
                ShowError(ex.Message);
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int grade = ParseGrade(txtGrade.Text);

                _manager.UpdateGrade(name, grade);
                AppendOutput($"Updated '{name.Trim()}' to grade {grade}.");
                RefreshGrid();
                ClearInputs();
            }
            catch (Exception ex) when (ex is StudentNotFoundException or InvalidGradeException
                                          or ArgumentException or FormatException)
            {
                ShowError(ex.Message);
            }
        }

        private void BtnRemove_Click(object? sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                if (string.IsNullOrWhiteSpace(name))
                {
                    ShowError("Enter or select the name of the student to remove.");
                    return;
                }

                _manager.RemoveStudent(name);
                AppendOutput($"Removed student '{name.Trim()}'.");
                RefreshGrid();
                ClearInputs();
            }
            catch (StudentNotFoundException ex)
            {
                ShowError(ex.Message);
            }
        }

        // ----- Search & Statistics ----------------------------------------------------

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            try
            {
                string name = txtSearchName.Text;
                int grade = _manager.SearchStudent(name);
                var category = GradeManager.GetGradeCategory(grade);

                AppendOutput($"'{name.Trim()}' has a grade of {grade} (Category {category}).");
            }
            catch (Exception ex) when (ex is StudentNotFoundException or ArgumentException)
            {
                ShowError(ex.Message);
            }
        }

        private void BtnAverage_Click(object? sender, EventArgs e)
        {
            try
            {
                double average = _manager.GetAverageGrade();
                AppendOutput($"Class average grade: {average:F2}");
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
        }

        private void BtnMinMax_Click(object? sender, EventArgs e)
        {
            try
            {
                var stats = _manager.GetStatistics();
                AppendOutput(
                    $"Highest grade: {stats.HighestGrade} ({stats.TopStudent})   |   " +
                    $"Lowest grade: {stats.LowestGrade} ({stats.LowestStudent})");
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
        }

        // ----- File menu ----------------------------------------------------------------

        private void SaveMenuItem_Click(object? sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FileName = "students.csv"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _manager.SaveToFile(dialog.FileName);
                AppendOutput($"Saved {_manager.Count} student(s) to '{dialog.FileName}'.");
            }
            catch (IOException ex)
            {
                ShowError($"Could not save file: {ex.Message}");
            }
        }

        private void LoadMenuItem_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                int loaded = _manager.LoadFromFile(dialog.FileName);
                AppendOutput($"Loaded {loaded} student record(s) from '{dialog.FileName}'.");
                RefreshGrid();
            }
            catch (IOException ex)
            {
                ShowError($"Could not load file: {ex.Message}");
            }
        }

        private void ExitMenuItem_Click(object? sender, EventArgs e) => Close();

        // ----- Keyboard input -------------------------------------------------------------

        private void TxtGrade_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnAdd_Click(sender, e);
            }
        }

        private void TxtSearchName_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnSearch_Click(sender, e);
            }
        }

        // ----- Grid helpers ------------------------------------------------------------------

        private void DgvStudents_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow is null)
                return;

            txtName.Text = dgvStudents.CurrentRow.Cells[colName.Index].Value?.ToString() ?? string.Empty;
            txtGrade.Text = dgvStudents.CurrentRow.Cells[colGrade.Index].Value?.ToString() ?? string.Empty;
        }

        private void RefreshGrid()
        {
            dgvStudents.Rows.Clear();

            foreach (var kv in _manager.Students.OrderBy(kv => kv.Key))
            {
                var category = GradeManager.GetGradeCategory(kv.Value);
                dgvStudents.Rows.Add(kv.Key, kv.Value, category.ToString());
            }
        }

        // ----- General helpers ---------------------------------------------------------------

        private static int ParseGrade(string text)
        {
            if (!int.TryParse(text.Trim(), out int grade))
                throw new FormatException("Grade must be a whole number.");

            return grade;
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtGrade.Clear();
            txtName.Focus();
        }

        private void AppendOutput(string message)
        {
            txtOutput.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
        }

        private void ShowError(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            AppendOutput($"Error: {message}");
        }
    }
}
