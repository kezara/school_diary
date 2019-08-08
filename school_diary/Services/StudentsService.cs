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
            logger.Info("converting student with AllStudentsDTOConverter, get all students");
            var studentsDTO = students.Select(x => Utilities.ConverterDTO.AllStudentsDTOConverter(x));

            return studentsDTO;
        }

        public IEnumerable<StudentDTOOut> GetStudentsByName(string name)
        {
            logger.Info("Accssesing db over Students rep, get students by name");
            IEnumerable<Student> students = db.StudentsRepository.Get(filter: x => x.FirstName == name);

            if (students.Count() < 1)
            {
                throw new StudentNotFoundException($"Student with name {name} does not exist!");
            }
            logger.Info("converting student with AllStudentsDTOConverter, get students by name");
            var studentsDTO = students.Select(x => Utilities.ConverterDTO.AllStudentsDTOConverter(x));

            return studentsDTO;
        }

        public IEnumerable<StudentDTOOut> GetStudentsByLastName(string lastName)
        {
            logger.Info("Accssesing db over Students rep, get students by lastname");
            IEnumerable<Student> students = db.StudentsRepository.Get(filter: x => x.LastName == lastName);

            if (students.Count() < 1)
            {
                throw new StudentNotFoundException($"Student with last name {lastName} does not exist!");
            }
            logger.Info("converting student with AllStudentsDTOConverter, get students by last name");
            var studentsDTO = students.Select(x => Utilities.ConverterDTO.AllStudentsDTOConverter(x));

            return studentsDTO;
        }

        public IEnumerable<StudentDTOOut> GetStudentsByNameLastName(string name, string lastName)
        {
            logger.Info("Accssesing db over Students rep, get students by name and lastname");
            IEnumerable<Student> students = db.StudentsRepository.Get(filter: x => x.FirstName == name && x.LastName == lastName);

            if (students.Count() < 1)
            {
                throw new StudentNotFoundException($"Student with name {name} and last name {lastName} does not exist!");
            }
            logger.Info("converting student with AllStudentsDTOConverter, get students by name and last name");
            var studentsDTO = students.Select(x => Utilities.ConverterDTO.AllStudentsDTOConverter(x));

            return studentsDTO;
        }

        public StudentDTOOutSingle GetStudentById(string id)
        {
            logger.Info("Accssesing db over Student rep, get student by id");
            Student student = db.StudentsRepository.Get(filter: x => x.Id == id).FirstOrDefault();
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with ID {id} doesn't exists");
            }
            logger.Info("converting student with StudentDTOConverter, get student by id");
            StudentDTOOutSingle studentDTO = Utilities.ConverterDTO.StudentDTOConverter(student);

            return studentDTO;
        }

        public StudentDTOOutSingle GetStudentByUserName(string username)
        {
            logger.Info("Accssesing db over Student rep, get student by username");
            Student student = db.StudentsRepository.Get(filter: x => x.UserName == username).FirstOrDefault();
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with username {username} doesn't exists");
            }
            logger.Info("converting student with StudentDTOConverter, get student by username");
            StudentDTOOutSingle studentDTO = Utilities.ConverterDTO.StudentDTOConverter(student);

            return studentDTO;
        }

        public Student GetStudent(string id)
        {
            logger.Info("Accsessing db over student repo, get student");
            Student student = db.StudentsRepository.Get(filter: x => x.Id == id).FirstOrDefault();
            if (student == null)
            {
                logger.Info("User with id {id} is not found");
                throw new StudentNotFoundException($"Student with id {id} is not here");
            }
            return student;
        }


        public Student AddStudentToClass(string id, StudentDepartmentDTO studentToUpdt)
        {
            Student student = GetStudent(id);
        //    student.FirstName = studentToUpdt.Student.FirstName;
        //    student.LastName = studentToUpdt.Student.LastName;
        //    //student.Parents = studentToUpdt.Student.Parents.Select(x => Utilities.ConverterDTO.SimpleDTOConverter<Parent>(x)).ToList();
        //    ////student.StudentDepartments.Departments = Utilities.ConverterDTO.SimpleDTOConverter<Department>(studentToUpdt.Department);
        //    ////student.StudentDepartments.Teaches = 
            
        //    StudentDepartment studentDepartment = new StudentDepartment()
        //    {
        //        EnrolmentTime = studentToUpdt.EnrolmentTime,
        //        Students = student,
        //        Departments = Utilities.ConverterDTO.SimpleDTOConverter<Department>(studentToUpdt.Department),
        //        //Teaches = studentToUpdt.Teaches.Select(x => new Teach()
        //        //{
        //        //    Subject = Utilities.ConverterDTO.SimpleDTOConverter<Subject>(x.Subject),
        //        //    Teachers = Utilities.ConverterDTO.SimpleDTOConverter<Teacher>(x.Teacher)
        //        //}).ToList()
        //};
            
            //Student studentTest = new Student();
            //Teacher teachertest = new Teacher();
            //studentTest.StudentDepartments.Teaches.Where(x => x.Teachers.Id == studentToUpdt.Id && x.Subject.Id == studentToUpdt.SubjectID);
            //StudentDTOOutSingle student = GetStudentByUserName(username);
            ////Department department = departmentsService.GetDepartmentByID(studentToUpdt.DepartmentID);
            //ParentDTOHelper mother = parentsService.GetParentByUserName(studentToUpdt.MotherUserName);
            //mother.Parent.
            //ParentDTOHelper father = parentsService.GetParentByUserName(studentToUpdt.FatherUserName);
            //ICollection<ParentDTOHelper> parents = new HashSet<ParentDTOHelper>();
            //parents.Add(mother);
            //parents.Add(father);
            ////student.StudentDepartments = department;
            //student.Parents = parents;
            //student.
            db.StudentsRepository.Update(student);
            db.Save();
            //StudentDTOOut studentDTOOutClass = new StudentDTOOut()
            //{
            //    ClassName = student.StudentDepartments.Departments.DepartmentName,
            //    FirstName = student.FirstName,
            //    LastName = student.LastName,
            //    UserName = student.UserName,
            //    MotherName = mother.FirstName,
            //    MotherSurname = mother.LastName,
            //    MotherUserName = mother.UserName,
            //    FatherName = father.FirstName,
            //    FatherSurname = father.LastName,
            //    FatherUserName = father.UserName
            //};
            return student;

            //    //}
        }
    }
}