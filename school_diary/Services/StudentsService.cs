using school_diary.Models;
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
        IAppUsersService usersService;
        public StudentsService(IUnitOfWork db, IAppUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public Student CreateStudent(Student newStudent)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.StudentsRepository.Insert(newStudent);
            db.Save();
            return newStudent;
        }

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
            return db.StudentsRepository.Get(filter: s => s.UserName == username).FirstOrDefault();
        }

        public Student UpdateStudent(string username, Student studentToUpdt)
        {
            Student student = GetStudentByUserName(username);

            //student.Id = studentToUpdt.Id;
            student.UserName = studentToUpdt.UserName;
            //student.TeacherUN = studentToUpdt.TeacherUN;
            //student.Grades = studentToUpdt.Grades;
            //student.SubjectID = studentToUpdt.SubjectID;
            //student.Students = studentToUpdt.Students;
            db.StudentsRepository.Update(student);
            db.Save();
            return studentToUpdt;
        }
    }
}