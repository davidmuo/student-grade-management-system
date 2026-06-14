namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Thrown when an operation refers to a student that does not exist.
    /// </summary>
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string studentName)
            : base($"Student '{studentName}' was not found.")
        {
        }
    }

    /// <summary>
    /// Thrown when attempting to add a student that already exists.
    /// </summary>
    public class DuplicateStudentException : Exception
    {
        public DuplicateStudentException(string studentName)
            : base($"Student '{studentName}' already exists.")
        {
        }
    }

    /// <summary>
    /// Thrown when a grade value falls outside the valid 0-100 range.
    /// </summary>
    public class InvalidGradeException : Exception
    {
        public InvalidGradeException(string message) : base(message)
        {
        }
    }
}
