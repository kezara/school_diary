using System.Collections.Generic;
using school_diary.Models;

namespace school_diary.Services
{
    public interface IStudentsService
    {
        Student CreateStudent(Student newStudent);
        Student DeleteStudent(string id);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentByUserName(string id);
        Student UpdateStudent(string id, Student studentToUpdt);
    }
}