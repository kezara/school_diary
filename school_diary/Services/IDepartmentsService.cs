using school_diary.Models;
using System.Collections.Generic;

namespace school_diary.Services
{
    public interface IDepartmentsService
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentByID(int id);
        Department CreateDepartment(Department newClass);
        Department UpdateDepartment(int id, Department classToUpdt);
        Department DeleteDepartment(int id);
    }
}