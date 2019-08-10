using System.Collections.Generic;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface IStudentsService
    {
        //Student CreateStudent(Student newStudent);
       // StudentDTOOut DeleteStudent(string id);
        IEnumerable<StudentDTOOut> GetAllStudents(string role, string userId);
        IEnumerable<StudentDTOOut> GetStudentsByName(string name, string role, string userId);
        IEnumerable<StudentDTOOut> GetStudentsByLastName(string lastName, string role, string userId);
        IEnumerable<StudentDTOOut> GetStudentsByNameLastName(string name, string lastName, string role, string userId);
        StudentDTOOutSingle GetStudentById(string id, string role, string userId);

        //Student AddStudentToClass(string id, StudentDTOIn studentToUpdt);
        Student GetStudent(string id);
        StudentDTOOutSingle GetStudentByUserName(string username, string role, string userId);
        //Student GetStudentByUserName(string username);
        //StudentDTOOut AddStudentToClass(string username, StudentDTOIn studentToUpdt);
    }
}