using SchoolManagement.Models;

public void CreateStudent(Student student)
{
    if (student.FullName.Length < 2 || student.FullName.Length > 100)
        throw new Exception("Full name must be between 2 and 100 characters.");

    if (_context.Students.Any(s => s.StudentCode == student.StudentCode))
        throw new Exception("Student ID already exists.");

    if (_context.Students.Any(s => s.Email == student.Email))
        throw new Exception("Email already exists.");

    _context.Students.Add(student);
    _context.SaveChanges();
}
