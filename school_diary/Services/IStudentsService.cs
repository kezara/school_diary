using System.Collections.Generic;
using school_diary.Models;

namespace school_diary.Services
{
    public interface IStudentsService
    {
        Student CreateStudent(Student newStudent);
        Student DeleteStudent(int id);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentByID(int id);
        Student UpdateStudent(int id, Student studentToUpdt);
    }
}