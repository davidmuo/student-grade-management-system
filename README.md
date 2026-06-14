# Student Grade Management System

A Windows desktop application (built with C# and Windows Forms / .NET) for managing
student names and grades. The app was built as part of a learning exercise covering
data structures, control flow, functions, exception handling, structs and enums.

## Features

- **Add a Student** – enter a name and a grade (0-100) and add it to the system.
  Data is stored in a `Dictionary<string, int>` mapping student name to grade.
- **Update a Student's Grade** – select a student in the grid (or type their name)
  and update their grade.
- **Remove a Student** – remove a student record from the system.
- **Display All Students** – every student, their grade, and their letter grade
  category (A/B/C/D/F, defined with an `enum`) are shown live in a table.
- **Search for a Student** – look up a student by name and display their grade and
  category, or a clear "not found" message if they don't exist.
- **Calculate Average Grade** – computes the average of every grade using LINQ's
  `Average()`.
- **Highest / Lowest Grade** – finds the top and bottom grades (and the students who
  earned them) using LINQ's `Max()` and `Min()`.
- **Save / Load** – save the current class list to a CSV file and reload it later
  (File menu).
- **Exception Handling** – the app gracefully handles:
  - Adding a duplicate student
  - Updating/removing/searching for a student that doesn't exist
  - Invalid grade values (non-numeric input or values outside 0-100)
  - Calculating statistics with no students added yet
  - File I/O errors when saving/loading

## Input Handling

The application supports **both** keyboard input and on-screen UI controls:

- Type a student's name and grade into the text boxes, then either click a button
  (**Add**, **Update**, **Remove**, **Search**, **Calculate Average**,
  **Highest / Lowest Grade**) or press **Enter** in the Grade/Search fields to
  trigger the action.
- Click a row in the student grid to load that student's name and grade back into
  the input fields for editing or removal.
- Use the **File** menu to save or load student data from a CSV file.

## Project Structure

```
StudentGradeManagementSystem.sln
StudentGradeManagementSystem/
├── Program.cs           # Application entry point
├── MainForm.cs          # Main window UI logic / event handlers
├── MainForm.Designer.cs # Main window layout (controls)
├── GradeManager.cs      # Core logic: Dictionary<string,int>, statistics, file I/O
├── GradeCategory.cs     # Enum representing letter grade categories (A-F)
└── Exceptions.cs        # Custom exceptions (StudentNotFoundException, etc.)
```

## How to Run

### Prerequisites

- [.NET SDK 8.0 or later](https://dotnet.microsoft.com/download) (Windows, with
  Windows Desktop workload for Windows Forms)

### Run from the command line

```bash
git clone <repository-url>
cd "Student Grade Management System"
dotnet run --project StudentGradeManagementSystem
```

### Run from Visual Studio / Visual Studio Code

1. Open `StudentGradeManagementSystem.sln` (or the `StudentGradeManagementSystem`
   folder) in your IDE.
2. Set `StudentGradeManagementSystem` as the startup project.
3. Press **F5** (or **Run**) to build and launch the app.

## Sample Usage

1. Enter a student name (e.g. `Alice`) and a grade (e.g. `95`), then click **Add
   Student** (or press Enter).
2. Repeat for additional students.
3. Click **Calculate Average** to see the class average.
4. Click **Highest / Lowest Grade** to see the top and bottom performers.
5. Type a name in the Search box and click **Search Grade** to look up a single
   student.
6. Use **File → Save to File...** to export the class list, and **File → Load from
   File...** to reload it later.
