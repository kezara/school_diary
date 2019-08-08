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
    public class TeachesService : ITeachesService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUnitOfWork db;
        IStudentDepartmentsService studentDepartmentsService;
        ITeachersService teachersService;
        IStudentsService studentsService;
        ISubjectsService subjectsService;
        public TeachesService(IUnitOfWork db, IStudentDepartmentsService studentDepartmentsService, ITeachersService teachersService,
            ISubjectsService subjectsService,IStudentsService studentsService)
        {
            this.db = db;
            this.studentDepartmentsService = studentDepartmentsService;
            this.subjectsService = subjectsService;
            this.teachersService = teachersService;
            this.studentsService = studentsService;            
        }

        public TeachDTOOut CreateTeach(TeachDTOIn newTeach)
        {
            logger.Info("Get student department over student department service, create teach teaches service");
            StudentDepartment studentDepartment = studentDepartmentsService.GetStudentDepartmentByID(newTeach.StudentDepartmentID);

            logger.Info("Get teacher over teacher service, create teach teaches service");
            Teacher teacher = teachersService.GetById(newTeach.TeacherID);

            logger.Info("Get subject over subject service, create teach teaches service");
            Subject subject = subjectsService.GetSubjectByID(newTeach.SubjectID);

            logger.Info("Get teaches over teach service, create teach teaches service");
            IEnumerable<Teach> teach = GetAllTeach();
            //Check if subject is for students grade
            logger.Info("Checking if subject is for the selected grade, create teaches, teaches service");
            var isGradeOk = subject.Grades.Contains(studentDepartment.Departments.Grades);
            if (!isGradeOk)
            {
                throw new SubjectIsNotForThisGrade("Wrong subject");
            }

            //check if teacher is teaching this subject
            logger.Info("Checking if teacher is teaching subject");
            var result = teacher.Subjects.Contains(subject);
            if (!result)
            {
                logger.Info("Throwing exception, wrong teacher subject pair");
                throw new TeacherDontTeachThisSubjectException("Teacher - subject pair does not match");
            }

            //check if subject is alreaady added to student
            logger.Info("Checking if subject is already added to student");
            var subjectExists = teach.Any(x => x.Subject.Equals(subject) && x.StudentDepartments.Equals(studentDepartment));
            if (subjectExists)
            {
                logger.Info("Throwing exception subject already added to student");
                throw new SubjectExistsException($"Subject {subject.SubjectName} already added to student {studentDepartment.Students.UserName}");
            }

            //check if teacher teach to this department, and finds who teach
            logger.Info("Checking if theacher is teach in department");
            var isDepartmentOK = teach.Any(x => x.Subject.Equals(subject) && x.Teachers.Equals(teacher) &&
            x.StudentDepartments.Departments.Id.Equals(studentDepartment.Departments.Id));
            var isSubjectInDepartment = teach.Any(x => x.Subject.Equals(subject) && x.StudentDepartments.Departments.Id.Equals(studentDepartment.Departments.Id));
            var whoTeach = teach.Where(x => x.Subject.Equals(subject) && x.StudentDepartments.Equals(studentDepartment)).Select(x => x.Teachers.UserName);
            if (!isDepartmentOK)
            {
                if (isSubjectInDepartment)
                {
                    logger.Info("Throwing exception teacher doesn't teach in department");
                    throw new TeacherDontTeachThisDepartment($"Teacher {teacher.UserName} doesn't teach to department {studentDepartment.Departments.DepartmentName}, {whoTeach} does.");
                }
            }

            logger.Info("Preparing teach for save in db");
            Teach teachIn = new Teach()
            {
                StudentDepartments = studentDepartment,
                Teachers = teacher,
                Subject = subject
            };
            logger.Info("Access to teaches repository for insert new teach");
            db.TeachesRepository.Insert(teachIn);
            logger.Info("db save new teach");
            db.Save();

            logger.Info("Converting to dto for output");
            TeachDTOOut teachDTOOut = new TeachDTOOut()
            {
                Id = teachIn.Id,
                Student = Utilities.ConverterDTO.SimpleDTOConverter<StudentDTO>(teachIn.StudentDepartments.Students),
                Department = Utilities.ConverterDTO.SimpleDTOConverter<DepartmentDTOStudent>(teachIn.StudentDepartments.Departments),
                TeacherSubject = studentDepartment.Teaches.Select(x => new TeacherSubjectDTO()
                {
                    Teacher = Utilities.ConverterDTO.SimpleDTOConverter<TeacherDTO>(x.Teachers),
                    Subject = Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(x.Subject)
                })
            };
            
            return teachDTOOut;
        }

        public Teach DeleteTeach(int id)
        {
            Teach teach = GetTeachByID(id);
            if (teach == null)
            {
                throw new UserNotFoundException($"Theach with ID {id} does not exists!!!");
            }
            db.TeachesRepository.Delete(id);
            db.Save();
            return teach;
        }

        public IEnumerable<Teach> GetAllTeach()
        {
            IEnumerable<Teach> teach = db.TeachesRepository.Get();
            if (teach == null)
            {
                throw new TeacherNotFoundException("Teaches doesn't exists.");
            }
            return teach;
        }

        public Teach GetTeachByID(int id)
        {
            return db.TeachesRepository.GetByID(id);
        }

        public Teach UpdateTeach(int id, Teach teachToUpdt)
        {
            Teach teach = GetTeachByID(id);

           // teach.Id = teachToUpdt.Id;
            //teach.Fond = teachToUpdt.Fond;
            db.TeachesRepository.Update(teach);
            db.Save();
            return teachToUpdt;
        }
    }
}