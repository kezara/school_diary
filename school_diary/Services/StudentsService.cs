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

        public Student DeleteStudent(int id)
        {
            Student student = GetStudentByID(id);
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

        public Student GetStudentByID(int id)
        {
            return db.StudentsRepository.GetByID(id);
        }

        public Student UpdateStudent(int id, Student studentToUpdt)
        {
            Student student = GetStudentByID(id);

            student.Id = studentToUpdt.Id;
            //student.Students = studentToUpdt.Students;
            db.StudentsRepository.Update(student);
            db.Save();
            return studentToUpdt;
        }
    }
}