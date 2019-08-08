using school_diary.Models;
using school_diary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using school_diary.Utilities.Exceptions;
using school_diary.Models.DTOs;
using NLog;

namespace school_diary.Services
{
    public class TeachersService : ITeachersService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUnitOfWork db;
        public TeachersService(IUnitOfWork db)
        {
            this.db = db;
        }

        //GET teacher by ID return teacher
        public Teacher GetById(string id)
        {
            logger.Info("Accssesing db over TEacher rep, get by id");
            Teacher teacher = db.TeachersRepository.Get(filter: x => x.Id.Contains(id)).FirstOrDefault();
            if (teacher == null)
            {
                throw new TeacherNotFoundException($"No teacher with id {id} here!");
            }
            return teacher;
        }
        //GET all teachers
        public IEnumerable<TeacherDTOOut> GetAllTeachers()
        {
            logger.Info("Accssesing db over TEacher rep, get all teachers");
            IEnumerable<Teacher> teachers = db.TeachersRepository.Get();
            if (teachers.Count() < 1)
            {
                throw new TeacherNotFoundException("No teachers here!");
            }

            IEnumerable<TeacherDTOOut> teacherDTO = teachers.Select(x => Utilities.ConverterDTO.TeacherDTOOutConverter(x));
            return teacherDTO;
        }
        
        //GET teachers by name
        public IEnumerable<TeacherDTOOut> GetTeachersByName(string name)
        {
            logger.Info("Accssesing db over TEacher rep, get teachers by name");
            IEnumerable<Teacher> teachers = db.TeachersRepository.Get(filter: x => x.FirstName.Contains(name));
            if (teachers.Count() < 1)
            {
                throw new TeacherNotFoundException($"No teachers with name {name} here!");
            }

            IEnumerable<TeacherDTOOut> teacherDTO = teachers.Select(x => Utilities.ConverterDTO.TeacherDTOOutConverter(x));
            return teacherDTO;
        }

        //GET teachers by last name
        public IEnumerable<TeacherDTOOut> GetTeachersByLastName(string lastName)
        {
            logger.Info("Accssesing db over TEacher rep, get teachers by last name");
            IEnumerable<Teacher> teachers = db.TeachersRepository.Get(filter: x => x.LastName.Contains(lastName));
            if (teachers.Count() < 1)
            {
                throw new TeacherNotFoundException($"No teachers with last name {lastName} here!");
            }

            IEnumerable<TeacherDTOOut> teacherDTO = teachers.Select(x => Utilities.ConverterDTO.TeacherDTOOutConverter(x));
            return teacherDTO;
        }

        //GET teachers by name and last name
        public IEnumerable<TeacherDTOOut> GetTeachersByNameLastName(string name, string lastName)
        {
            logger.Info("Accssesing db over TEacher rep, get teachers by name and last name");
            IEnumerable<Teacher> teachers = db.TeachersRepository.Get(filter: x => x.FirstName.Contains(name) && x.LastName.Contains(lastName));
            if (teachers.Count() < 1)
            {
                throw new TeacherNotFoundException($"No teachers with name {name} and last name {lastName} here!");
            }

            IEnumerable<TeacherDTOOut> teacherDTO = teachers.Select(x => Utilities.ConverterDTO.TeacherDTOOutConverter(x));
            return teacherDTO;
        }

        //GET teacher by ID
        public TeacherDTOOut GetTeacherById(string id)
        {
            logger.Info("Accssesing db over TEacher rep, get teacher by id");
            Teacher teacher = db.TeachersRepository.Get(filter: x => x.Id.Contains(id)).FirstOrDefault();
            if (teacher == null)
            {
                throw new TeacherNotFoundException($"No teacher with id {id} here!");
            }

            TeacherDTOOut teacherDTO = Utilities.ConverterDTO.TeacherDTOOutConverter(teacher);
            return teacherDTO;
        }

        //GET teacher by username
        public TeacherDTOOut GetTeacherByUsername(string username)
        {
            logger.Info("Accssesing db over TEacher rep, get teacher by username");
            Teacher teacher = db.TeachersRepository.Get(filter: x => x.Id.Contains(username)).FirstOrDefault();
            if (teacher == null)
            {
                throw new TeacherNotFoundException($"No teacher with id {username} here!");
            }

            TeacherDTOOut teacherDTO = Utilities.ConverterDTO.TeacherDTOOutConverter(teacher);
            return teacherDTO;
        }
        

        //public Teacher UpdateTeacher(int id, Teacher teacherToUpdt)
        //{
        //    Teacher teacher = GetTeacherByID(id);

        //    teacher.Id = teacherToUpdt.Id;
        //    //teacher.TeacherID = teacherToUpdt.TeacherID;
        //    //teacher.Teachers = teacherToUpdt.Teachers;
        //    db.TeachersRepository.Update(teacher);
        //    db.Save();
        //    return teacherToUpdt;
        //}
    }
}