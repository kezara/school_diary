using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using school_diary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        IUnitOfWork db;

        public DepartmentsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Department CreateDepartment(Department newDepartment)
        {
            //ClassRoom newDepartment = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.DepartmentsRepository.Insert(newDepartment);
            db.Save();
            return newDepartment;
        }

        public Department DeleteDepartment(int id)
        {
            Department department = GetDepartmentByID(id);
            if (department == null)
            {
                throw new UserNotFoundException();
            }
            db.DepartmentsRepository.Delete(id);
            db.Save();
            return department;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return db.DepartmentsRepository.Get();
        }

        public Department GetDepartmentByID(int id)
        {
            return db.DepartmentsRepository.GetByID(id);
        }

        public Department UpdateDepartment(int id, Department departmentToUpdt)
        {
            Department department = GetDepartmentByID(id);

            department.Id = departmentToUpdt.Id;
            //department.Year = departmentToUpdt.Year;
            department.DepartmentName = departmentToUpdt.DepartmentName;
            //department.Subjects = department.Subjects;
            //department.Teachers = department.Teachers;
            db.DepartmentsRepository.Update(department);
            db.Save();
            return departmentToUpdt;
        }
    }
}