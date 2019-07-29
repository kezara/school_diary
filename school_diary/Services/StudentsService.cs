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

        public Student DeleteStudent(string id)
        {
            Student student = GetStudentByUserName(id);
            if (student == null)
            {
                throw new UserNotFoundException();
            }
            db.StudentsRepository.Delete(id);
            db.Save();
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.StudentsRepository.Get();
        }

        public Student GetStudentByUserName(string username)
        {
            Student student = db.StudentsRepository.Get(filter: s => s.UserName == username).FirstOrDefault();
            if (student == null)
            {
                throw new UserNotFoundException();
            }
            return student;
        }

        public StudentDTOOutClass AddStudentToClass(string username, StudentDTOInClass studentToUpdt)
        {
            try
            {
                Student student = GetStudentByUserName(username);
                //Department department = departmentsService.GetDepartmentByID(studentToUpdt.DepartmentID);
                Parent mother = parentsService.GetParentByUserName(studentToUpdt.MotherUserName);
                Parent father = parentsService.GetParentByUserName(studentToUpdt.FatherUserName);
                ICollection<Parent> parents = new HashSet<Parent>();
                parents.Add(mother);
                parents.Add(father);
                //student.StudentDepartments = department;
                student.Parents = parents;
                db.StudentsRepository.Update(student);
                db.Save();
                StudentDTOOutClass studentDTOOutClass = new StudentDTOOutClass()
                {
                    ClassName = student.StudentDepartments.Departments.DepartmentName,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    UserName = student.UserName,
                    MotherName = mother.FirstName,
                    MotherSurname = mother.LastName,
                    MotherUserName = mother.UserName,
                    FatherName = father.FirstName,
                    FatherSurname = father.LastName,
                    FatherUserName = father.UserName
                };
                return studentDTOOutClass;
            }
            catch (UserNotFoundException)
            {
                throw new UserNotFoundException();
            }
        }
    }
}