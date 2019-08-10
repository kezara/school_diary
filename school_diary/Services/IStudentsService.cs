using System.Collections.Generic;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface IStudentsService
    {
       // StudentDTOOut DeleteStudent(string id);
        IEnumerable<StudentDTOOut> GetAllStudents(string role, string userId);
        IEnumerable<StudentDTOOut> GetStudentsByName(string name, string role, string userId);
        IEnumerable<StudentDTOOut> GetStudentsByLastName(string lastName, string role, string userId);
        IEnumerable<StudentDTOOut> GetStudentsByNameLastName(string name, string lastName, string role, string userId);
        StudentDTOOutSingle GetStudentById(string id, string role, string userId);
        Student GetStudent(string id);

        StudentDTOOutSingle AddParentToStudent(string id, StudentDTOInAddParent student);
        StudentDTOOutSingle GetStudentByUserName(string username, string role, string userId);
    }
}