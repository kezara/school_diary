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
        IEnumerable<StudentDTOOut> GetStudentsByName(string name);
        IEnumerable<StudentDTOOut> GetStudentsByLastName(string lastName);
        IEnumerable<StudentDTOOut> GetStudentsByNameLastName(string name, string lastName);
        StudentDTOOutSingle GetStudentById(string id);
        StudentDTOOutSingle GetStudentByUserName(string username);
        //Student GetStudentByUserName(string username);
        //StudentDTOOut AddStudentToClass(string username, StudentDTOIn studentToUpdt);
    }
}