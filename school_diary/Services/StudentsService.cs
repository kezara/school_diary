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
    public class StudentsService : IStudentsService
    {
        public static Logger logger = LogManager.GetCurrentClassLogger(); 
        IUnitOfWork db;
        IDepartmentsService departmentsService;
        IParentsService parentsService;
        public StudentsService(IUnitOfWork db, IDepartmentsService departmentsService, IParentsService parentsService)
        {
            this.db = db;
            this.departmentsService = departmentsService;
            this.parentsService = parentsService;
        }

        //public Student CreateStudent(Student newStudent)
        //{
        //    //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
        //    db.StudentsRepository.Insert(newStudent);
        //    db.Save();
        //    return newStudent;
        //}

        //public StudentDTOOut DeleteStudent(string id)
        //{
        //    StudentDTOOut student = GetStudentById(id);

        //    db.StudentsRepository.Delete(id);
        //    db.Save();
        //    return student;
        //}

        public IEnumerable<StudentDTOOut> GetAllStudents()
        {
            logger.Info("Accssesing db over Students rep, get all students");
            IEnumerable<Student> students = db.StudentsRepository.Get();

            if (students.Count() < 1)
            {
                throw new StudentNotFoundException("No students here!");
            }
            var studentsDTO = students.Select(x => Utilities.ConverterDTO.AllStudentsDTOConverter(x));
            
            return studentsDTO;
        }



        public StudentDTOOutSingle GetStudentById(string id)
        {
            logger.Info("Accssesing db over Student rep, get student by id");
            Student student = db.StudentsRepository.GetByID(id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with ID {id} doesn't exists");
            }
            logger.Info("converting admin with SimpleDTOConverter, get admin by id");
            StudentDTOOutSingle studentDTO = Utilities.ConverterDTO.StudentDTOConverter(student);

            return studentDTO;
        }

        //public AdminDTOOut GetAdminByUserName(string username)
        //{
        //    logger.Info("Accessing db over admin repo, get admin by username");
        //    Admin admin = db.AdminsRepository.Get(filter: x => x.UserName == username).FirstOrDefault();
        //    if (admin == null)
        //    {
        //        throw new AdminNotFoundException($"Requested admin with username {username} does not exists");
        //    }
        //    logger.Info("converting with simpleDTOConverter, get admin by username");
        //    AdminDTOOut adminDTOOut = Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOut>(admin);

        //    return adminDTOOut;
        //}

        //public IEnumerable<AdminDTOOut> GetAdminByName(string name)
        //{
        //    logger.Info("Accessing db over admin repo, get admin by name");
        //    IEnumerable<Admin> admins = db.AdminsRepository.Get(filter: x => x.FirstName == name);
        //    if (admins.Count() < 1)
        //    {
        //        throw new AdminNotFoundException($"No admins with requested name {name} inhere");
        //    }
        //    HashSet<AdminDTOOut> adminsDTOOut = new HashSet<AdminDTOOut>();
        //    foreach (var admin in admins)
        //    {
        //        logger.Info("converting with simpledtoconverter, foreach, get admin by name");
        //        var adminDTOOut = Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOut>(admin);
        //        adminsDTOOut.Add(adminDTOOut);
        //    }

        //    IEnumerable<AdminDTOOut> iadminsDTOOut = adminsDTOOut;

        //    return iadminsDTOOut;
        //}

        //public IEnumerable<AdminDTOOut> GetAdminByLastName(string lastName)
        //{
        //    logger.Info("Accessing db over admin repo, get admin by lastname");
        //    IEnumerable<Admin> admins = db.AdminsRepository.Get(filter: x => x.LastName == lastName);
        //    if (admins.Count() < 1)
        //    {
        //        throw new AdminNotFoundException($"No admins with requested surname {lastName} inhere!");
        //    }
        //    HashSet<AdminDTOOut> adminsDTOOut = new HashSet<AdminDTOOut>();
        //    foreach (var admin in admins)
        //    {
        //        logger.Info("converting with simpledtoconverter, foreach, get admin by lastname");
        //        var adminDTOOut = Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOut>(admin);
        //        adminsDTOOut.Add(adminDTOOut);
        //    }

        //    IEnumerable<AdminDTOOut> iadminsDTOOut = adminsDTOOut;

        //    return iadminsDTOOut;
        //}

        //public IEnumerable<AdminDTOOut> GetAdminByNameLastName(string name, string lastName)
        //{
        //    logger.Info("Accessing db over admin repo, get admin by name and lastname");
        //    IEnumerable<Admin> admins = db.AdminsRepository.Get(filter: x => x.FirstName == name && x.LastName == lastName);
        //    if (admins.Count() < 1)
        //    {
        //        throw new AdminNotFoundException($"No admins with that name {name} and surname {lastName}");
        //    }
        //    HashSet<AdminDTOOut> adminsDTOOut = new HashSet<AdminDTOOut>();
        //    foreach (var admin in admins)
        //    {
        //        logger.Info("converting with simpledtoconverter, foreach, get admin by lastname");
        //        var adminDTOOut = Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOut>(admin);
        //        adminsDTOOut.Add(adminDTOOut);
        //    }

        //    IEnumerable<AdminDTOOut> iadminsDTOOut = adminsDTOOut;

        //    return iadminsDTOOut;
        //}

        //public AdminDTOOut DeleteAdmin(string id)
        //{
        //    AdminDTOOut admin = GetAdminById(id);
        //    db.AdminsRepository.Delete(id);
        //    db.Save();
        //    return admin;
        //}

        ////IEnumerable<Parent> parents = parentsService.GetParentByUserName(student.Parents);
        ////Parent father = parentsService.GetParentByUserName(student.FatherUserName);
        ////ICollection<Parent> parents = new HashSet<Parent>();
        ////parents.Add(mother);
        ////parents.Add(father);
        ////student.StudentDepartments = department;
        ////student.Parents = parents;

        //StudentDTOOut studentDTOOut = new StudentDTOOut()
        //    {
        //        ClassName = student.StudentDepartments.Departments.DepartmentName,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName,
        //        UserName = student.UserName,
        //        //MotherName = mother.FirstName,
        //        //MotherSurname = mother.LastName,
        //        //MotherUserName = mother.UserName,
        //        //FatherName = father.FirstName,
        //        //FatherSurname = father.LastName,
        //        //FatherUserName = father.UserName
        //    };

        //    return studentDTOOut;
        //}

        //public StudentDTOOut AddStudentToClass(string username, StudentDTOIn studentToUpdt)
        //{

        //        Student student = GetStudentByUserName(username);
        //        //Department department = departmentsService.GetDepartmentByID(studentToUpdt.DepartmentID);
        //        Parent mother = parentsService.GetParentByUserName(studentToUpdt.MotherUserName);
        //        Parent father = parentsService.GetParentByUserName(studentToUpdt.FatherUserName);
        //        ICollection<Parent> parents = new HashSet<Parent>();
        //        parents.Add(mother);
        //        parents.Add(father);
        //        //student.StudentDepartments = department;
        //        student.Parents = parents;
        //        db.StudentsRepository.Update(student);
        //        db.Save();
        //        StudentDTOOut studentDTOOutClass = new StudentDTOOut()
        //        {
        //            ClassName = student.StudentDepartments.Departments.DepartmentName,
        //            FirstName = student.FirstName,
        //            LastName = student.LastName,
        //            UserName = student.UserName,
        //            MotherName = mother.FirstName,
        //            MotherSurname = mother.LastName,
        //            MotherUserName = mother.UserName,
        //            FatherName = father.FirstName,
        //            FatherSurname = father.LastName,
        //            FatherUserName = father.UserName
        //        };
        //        return studentDTOOutClass;

        //}
    }
}