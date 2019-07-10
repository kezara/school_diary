using school_diary.Models;
using school_diary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using school_diary.Utilities.Exceptions;

namespace school_diary.Services
{
    public class TeachersService : ITeachersService
    {
        IUnitOfWork db;
        public TeachersService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Teacher CreateTeacher(Teacher newTeacher)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.TeachersRepository.Insert(newTeacher);
            db.Save();
            return newTeacher;
        }

        public Teacher DeleteTeacher(int id)
        {
            Teacher teacher = GetTeacherByID(id);
            if (teacher == null)
            {
                throw new UserNotFoundException();
            }
            db.AdminsRepository.Delete(id);
            db.Save();
            return teacher;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return db.TeachersRepository.Get();
        }

        public Teacher GetTeacherByID(int id)
        {
            return db.TeachersRepository.GetByID(id);
        }

        public Teacher UpdateTeacher(int id, Teacher teacherToUpdt)
        {
            Teacher teacher = GetTeacherByID(id);

            teacher.Id = teacherToUpdt.Id;
            teacher.TeacherID = teacherToUpdt.TeacherID;
            //teacher.Teachers = teacherToUpdt.Teachers;
            db.TeachersRepository.Update(teacher);
            db.Save();
            return teacherToUpdt;
        }
    }
}