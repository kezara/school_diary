using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using school_diary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using school_diary.Models.DTOs;

namespace school_diary.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        IUnitOfWork db;
        IGradeService gradesService;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DepartmentsService(IUnitOfWork db, IGradeService gradesService)
        {
            this.db = db;
            this.gradesService = gradesService;
        }

        public DepartmentDTOCreated CreateDepartment(DepartmentDTOIn newDepartment)
        {
            logger.Info("Getting grades for creating department over grades service, create department, department service");
            Grade grade = gradesService.GetGradeId(newDepartment.GradeID);

            logger.Info($"Creating department {newDepartment.DepartmentName}");
            Department department = new Department()
            {
                DepartmentName = newDepartment.DepartmentName,
                Grades = grade
            };

            logger.Info($"Adding department {department.DepartmentName} to db");
            db.DepartmentsRepository.Insert(department);
            db.Save();

            logger.Info("Converting department to DTO");
            DepartmentDTOCreated departmentDTO = new DepartmentDTOCreated()
            {
                DepartmentName = department.DepartmentName,
                Grade = Utilities.ConverterDTO.SimpleDTOConverter<GradeDTO>(department.Grades)
            };

            return departmentDTO;
        }

        public DepartmentDTOOutSingle DeleteDepartment(int id)
        {
            logger.Info("Getting department by id, preparing for delete, deletedepartment, department service");
            DepartmentDTOOutSingle departmentDTO = GetDepartmentByID(id);
            if (departmentDTO == null)
            {
                logger.Info($"Department with ID {id} not found, throwing department not found exception");
                throw new DepartmentNotFoundException($"No department with ID {id}");
            }
            logger.Info($"Accessing department repo for delete of department id {id}");
            db.DepartmentsRepository.Delete(id);
            logger.Info($"Saving to db, department with ID {id} delete");
            db.Save();

            logger.Info($"Department id {id} deleted, returning deprtmentDTO");
            return departmentDTO;
        }

        public IEnumerable<DepartmentDTOOut> GetAllDepartments()
        {
            logger.Info("Accessing departments repo, getalldepartments, departments service");
            IEnumerable<Department> departments = db.DepartmentsRepository.Get();
            if (departments.Count() < 1)
            {
                throw new DepartmentNotFound("No departments here");
            }

            IEnumerable<DepartmentDTOOut> departmentsDTO = departments.Select(x => new DepartmentDTOOut()
            {
                Department = Utilities.ConverterDTO.SimpleDTOConverter<DepartmentDTOStudent>(x),
                Grade = Utilities.ConverterDTO.SimpleDTOConverter<GradeDTO>(x.Grades),
            });

            return departmentsDTO;
        }

        public DepartmentDTOOutSingle GetDepartmentByID(int id)
        {
            logger.Info("Accessing department repo, getdepartmentbyid, departments service");
            Department department = db.DepartmentsRepository.GetByID(id);
            if (department == null)
            {
                throw new DepartmentNotFound($"Departments with {id} doesent exists");
            }

            DepartmentDTOOutSingle departmentDTO = new DepartmentDTOOutSingle()
            {
                Department = new DepartmentDTOStudent()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName
                },
                Grade = ConverterDTO.SimpleDTOConverter<GradeDTO>(department.Grades),
                Subjects = department.Grades.Subjects.Select(x => ConverterDTO.SimpleDTOConverter<SubjectDTO>(x))
            };
            return departmentDTO;
        }

        public Department GetDepartmentId(int id)
        {
            logger.Info("Accessing department repo, getdepartmentbyid, departments service");
            Department department = db.DepartmentsRepository.GetByID(id);
            if (department == null)
            {
                throw new DepartmentNotFound($"Departments with {id} doesent exists");
            }

            return department;
        }


        public DepartmentDTOUpdateOut UpdateDepartment(int id, DepartmentDTOStudent departmentToUpdt)
        {
            logger.Info($"Getting department {id}, updatedepartment, department service");
            Department department = GetDepartmentId(id);

            logger.Info($"Making updates");
            department.DepartmentName = departmentToUpdt.DepartmentName;
            //department2.Grades = grade;

            logger.Info($"Converting to department and prepare for storing updates, updatedepartment, department service");


            logger.Info($"Accessing department repository, for update department, department service");
            db.DepartmentsRepository.Update(department);
            logger.Info($"Saving changes to db id {id}");
            db.Save();
            DepartmentDTOUpdateOut departmentDTO = new DepartmentDTOUpdateOut()
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                Grade = Utilities.ConverterDTO.SimpleDTOConverter<GradeDTO>(department.Grades)
            };
            logger.Info($"returning department to controller, department service, updatedepartment");
            return departmentDTO;
        }
    }
}