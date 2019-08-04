using System.Collections.Generic;
using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface ITeachersService
    {
        //Teacher CreateTeacher(Teacher newTeacher);
        //Teacher DeleteTeacher(int id);
        IEnumerable<TeacherDTOOut> GetAllTeachers();
        IEnumerable<TeacherDTOOut> GetTeachersByName(string name);
        IEnumerable<TeacherDTOOut> GetTeachersByLastName(string lastName);
        IEnumerable<TeacherDTOOut> GetTeachersByNameLastName(string name, string lastName);
        TeacherDTOOut GetTeacherById(string Id);
        TeacherDTOOut GetTeacherByUsername(string username);
        //Teacher GetTeacherByID(int id);
        //Teacher UpdateTeacher(int id, Teacher teacherToUpdt);
    }
}