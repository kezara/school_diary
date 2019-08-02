using System.Collections.Generic;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface IStudentsService
    {
        //Student CreateStudent(Student newStudent);
       // StudentDTOOut DeleteStudent(string id);
        IEnumerable<StudentDTOOut> GetAllStudents();
        StudentDTOOutSingle GetStudentById(string id);
        //Student GetStudentByUserName(string username);
        //StudentDTOOut AddStudentToClass(string username, StudentDTOIn studentToUpdt);
    }
}