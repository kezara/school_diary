using school_diary.Models;
using school_diary.Models.DTOs;
using System.Collections.Generic;

namespace school_diary.Services
{
    public interface IDepartmentsService
    {
        IEnumerable<DepartmentDTOOut> GetAllDepartments();
        DepartmentDTOOutSingle GetDepartmentByID(int id);
        DepartmentDTOCreated CreateDepartment(DepartmentDTOIn newClass);
        DepartmentDTOUpdateOut UpdateDepartment(int id, DepartmentDTOStudent classToUpdt);
        DepartmentDTOOutSingle DeleteDepartment(int id);

        Department GetDepartmentId(int id);
    }
}