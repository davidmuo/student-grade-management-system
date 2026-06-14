using System.Text;

namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Holds a snapshot of class-wide statistics produced from the grade dictionary.
    /// </summary>
    public struct GradeStatistics
    {
        public double Average;
        public string TopStudent;
        public int HighestGrade;
        public string LowestStudent;
        public int LowestGrade;
    }

    /// <summary>
    /// Core business logic for managing student names and grades.
    /// All student data is stored in a single Dictionary&lt;string, int&gt;
    /// mapping a student's name to their numeric grade (0-100).
    /// </summary>
    public class GradeManager
    {
        private readonly Dictionary<string, int> _students = new();

        /// <summary>Read-only view of the underlying student/grade dictionary.</summary>
        public IReadOnlyDictionary<string, int> Students => _students;

        public int Count => _students.Count;

        /// <summary>
        /// Adds a new student with the given grade.
        /// </summary>
        /// <exception cref="DuplicateStudentException">The student already exists.</exception>
        /// <exception cref="InvalidGradeException">The grade is outside 0-100.</exception>
        public void AddStudent(string name, int grade)
        {
            name = ValidateName(name);
            ValidateGrade(grade);

            if (_students.ContainsKey(name))
                throw new DuplicateStudentException(name);

            _students.Add(name, grade);
        }

        /// <summary>
        /// Updates the grade of an existing student.
        /// </summary>
        /// <exception cref="StudentNotFoundException">No student with that name exists.</exception>
        /// <exception cref="InvalidGradeException">The grade is outside 0-100.</exception>
        public void UpdateGrade(string name, int grade)
        {
            name = ValidateName(name);
            ValidateGrade(grade);

            if (!_students.ContainsKey(name))
                throw new StudentNotFoundException(name);

            _students[name] = grade;
        }

        /// <summary>
        /// Removes a student from the dictionary.
        /// </summary>
        /// <exception cref="StudentNotFoundException">No student with that name exists.</exception>
        public void RemoveStudent(string name)
        {
            name = ValidateName(name);

            if (!_students.Remove(name))
                throw new StudentNotFoundException(name);
        }

        /// <summary>
        /// Searches for a student and returns their grade.
        /// </summary>
        /// <exception cref="StudentNotFoundException">No student with that name exists.</exception>
        public int SearchStudent(string name)
        {
            name = ValidateName(name);

            if (!_students.TryGetValue(name, out int grade))
                throw new StudentNotFoundException(name);

            return grade;
        }

        /// <summary>
        /// Calculates the average of all stored grades.
        /// </summary>
        /// <exception cref="InvalidOperationException">There are no students yet.</exception>
        public double GetAverageGrade()
        {
            if (_students.Count == 0)
                throw new InvalidOperationException("No students have been added yet.");

            return _students.Values.Average();
        }

        /// <summary>
        /// Computes overall class statistics (average, highest and lowest grades)
        /// using LINQ's Max() and Min() helpers.
        /// </summary>
        /// <exception cref="InvalidOperationException">There are no students yet.</exception>
        public GradeStatistics GetStatistics()
        {
            if (_students.Count == 0)
                throw new InvalidOperationException("No students have been added yet.");

            int highest = _students.Values.Max();
            int lowest = _students.Values.Min();

            return new GradeStatistics
            {
                Average = _students.Values.Average(),
                HighestGrade = highest,
                LowestGrade = lowest,
                TopStudent = _students.First(kv => kv.Value == highest).Key,
                LowestStudent = _students.First(kv => kv.Value == lowest).Key
            };
        }

        /// <summary>
        /// Converts a numeric grade (0-100) into its letter GradeCategory.
        /// </summary>
        /// <exception cref="InvalidGradeException">The grade is outside 0-100.</exception>
        public static GradeCategory GetGradeCategory(int grade)
        {
            ValidateGrade(grade);

            return grade switch
            {
                >= 90 => GradeCategory.A,
                >= 80 => GradeCategory.B,
                >= 70 => GradeCategory.C,
                >= 60 => GradeCategory.D,
                _ => GradeCategory.F
            };
        }

        /// <summary>
        /// Saves all students to a simple "name,grade" CSV file.
        /// </summary>
        public void SaveToFile(string path)
        {
            var sb = new StringBuilder();
            foreach (var kv in _students)
                sb.AppendLine($"{kv.Key},{kv.Value}");

            File.WriteAllText(path, sb.ToString());
        }

        /// <summary>
        /// Loads students from a "name,grade" CSV file, replacing current data.
        /// Lines that are malformed or contain invalid grades are skipped.
        /// </summary>
        public int LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found: {path}");

            _students.Clear();
            int loaded = 0;

            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');
                if (parts.Length != 2)
                    continue;

                if (int.TryParse(parts[1].Trim(), out int grade) &&
                    grade is >= 0 and <= 100 &&
                    !string.IsNullOrWhiteSpace(parts[0]))
                {
                    _students[parts[0].Trim()] = grade;
                    loaded++;
                }
            }

            return loaded;
        }

        private static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.", nameof(name));

            return name.Trim();
        }

        private static void ValidateGrade(int grade)
        {
            if (grade < 0 || grade > 100)
                throw new InvalidGradeException("Grade must be between 0 and 100.");
        }
    }
}
