using System.Collections.Generic;
using school_diary.Models;

namespace school_diary.Services
{
    public interface ITeachersService
    {
        Teacher CreateTeacher(Teacher newTeacher);
        Teacher DeleteTeacher(int id);
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacherByID(int id);
        Teacher UpdateTeacher(int id, Teacher teacherToUpdt);
    }
}