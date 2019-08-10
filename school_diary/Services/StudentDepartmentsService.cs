using NLog;
using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class StudentDepartmentsService : IStudentDepartmentsService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUnitOfWork db;
        IStudentsService studentsService;
        IDepartmentsService departmentsService;
        //ITeachersService teachersService;
        //ISubjectsService subjectsService;
        public StudentDepartmentsService(IUnitOfWork db, IStudentsService studentsService, IDepartmentsService departmentsService)
        {
            this.db = db;
            this.studentsService = studentsService;
            this.departmentsService = departmentsService;
            //this.teachersService = teachersService;
            //this.subjectsService = subjectsService;
        }

        public StudentDepartment GetStudentDepartmentByID(int id)
        {
            logger.Info($"accessing db over student department service, find student department by ID {id}");
            var studentDepartment = db.StudentDepartmentsRepository.GetByID(id);
            if (studentDepartment == null)
            {
                throw new StudentDepartmentNotFoundException("Student's not enrolled in this department");
            }
            return studentDepartment;
        }

        public StudentDepartmentDTOenrolled CreateStudentDepartment(StudentDepartmentDTO studentDepartmentDTO)
        {
            logger.Info($"Searching for student with ID {studentDepartmentDTO.StudentID} over student service, create student department, student department service");
            Student student = studentsService.GetStudent(studentDepartmentDTO.StudentID);
            logger.Info($"searching for department with id {studentDepartmentDTO.DepartmentID} over student service, create student department, student department service");
            Department department = departmentsService.GetDepartmentId(studentDepartmentDTO.DepartmentID);
            
            logger.Info($"Converting from DTO, createStudent department, student department service");
            StudentDepartment studentDepartment = new StudentDepartment()
            {
                EnrolmentTime = studentDepartmentDTO.EnrolmentTime,
                Students = student,
                Departments = department                
            };
            logger.Info($"Sending student {studentDepartment.Students.UserName} {studentDepartment.Departments.DepartmentName} to db over student department repository, student" +
                $"department service, create student department");
            db.StudentDepartmentsRepository.Insert(studentDepartment);
            logger.Info($"Saving student {studentDepartment.Students.UserName} {studentDepartment.Departments.DepartmentName} to db over student department repository, student" +
                $"department service, create student department");
            db.Save();
            logger.Info($"Converting student department to DTO, create student department, student department service");
            StudentDepartmentDTOenrolled studentEnrolled = new StudentDepartmentDTOenrolled()
            {
                Student = Utilities.ConverterDTO.SimpleDTOConverter<StudentDTOIn>(studentDepartment.Students),
                Department = Utilities.ConverterDTO.SimpleDTOConverter<DepartmentDTOStudent>(studentDepartment.Departments),
                Grade = Utilities.ConverterDTO.SimpleDTOConverter<GradeDTOOut>(studentDepartment.Departments.Grades),
                StudentDepartmentId = studentDepartment.Id
            };

            return studentEnrolled;
        }
    }
}