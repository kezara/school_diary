using System.Collections.Generic;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface IStudentsService
    {
        //Student CreateStudent(Student newStudent);
        Student DeleteStudent(string id);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentByUserName(string username);
        StudentDTOOutClass AddStudentToClass(string username, StudentDTOInClass studentToUpdt);
    }
}