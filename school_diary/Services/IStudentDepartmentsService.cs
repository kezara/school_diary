using school_diary.Models;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public interface IStudentDepartmentsService
    {
        StudentDepartmentDTOenrolled CreateStudentDepartment(StudentDepartmentDTO studentDepartment);
        StudentDepartment GetStudentDepartmentByID(int id);
    }
}