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
    public class SubjectsService : ISubjectsService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUnitOfWork db;
        ITeachersService teachersService;
        public SubjectsService(IUnitOfWork db, ITeachersService teachersService)
        {
            this.db = db;
            this.teachersService = teachersService;
        }

        public SubjectDTO CreateSubject(SubjectDTO newSubject)
        {
            Subject subject = Utilities.ConverterDTO.SimpleDTOConverter<Subject>(newSubject);
            db.SubjectsRepository.Insert(subject);
            db.Save();
            SubjectDTO subjectDTO = Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(subject);
            return subjectDTO;
        }

        public SubjectDTO DeleteSubject(int id)
        {
            Subject subject = GetSubjectByID(id);

            db.SubjectsRepository.Delete(id);
            db.Save();
            SubjectDTO subjectDTO = Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(subject);
            
            return subjectDTO;
        }

        public IEnumerable<SubjectTeacherDTOOut> GetAllSubjects()
        {
            logger.Info("Accssesing db over subjects rep, get all subjects");
            IEnumerable<Subject> subjects = db.SubjectsRepository.Get();
            if (subjects.Count() < 1)
            {
                throw new SubjectNotFoundException("No subjects here!");
            }
            IEnumerable<SubjectTeacherDTOOut> subjectTeacherDTOOuts = subjects.Select(x => new SubjectTeacherDTOOut()
            {
                Subject = Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(x),
                Teachers = x.Teachers.Select(y => Utilities.ConverterDTO.SimpleDTOConverter<TeacherDTOOutReg>(y))
            });
            return subjectTeacherDTOOuts;
        }


        public Subject GetSubjectByID(int id)
        {
            Subject subject = db.SubjectsRepository.GetByID(id);
            if (subject == null)
            {
                throw new SubjectNotFoundException($"No subject with id {id}");
            }

            return subject;
        }

        public SubjectTeacherDTOOut AddTeacherToSubject(int id, SubjectTEacherDTOIn subjectToUpdt)
        {
            Subject subject = GetSubjectByID(id);
            HashSet<Teacher> teachers = new HashSet<Teacher>();
            foreach (var ID in subjectToUpdt.TeacherID)
            {
                Teacher teacher = teachersService.GetById(ID);
                teachers.Add(teacher);
            }

            subject.Teachers = teachers;

            db.SubjectsRepository.Update(subject);
            db.Save();

            IEnumerable<TeacherDTOOutReg> teachersUpdate = teachers.Select(x => Utilities.ConverterDTO.SimpleDTOConverter<TeacherDTOOutReg>(x));
            SubjectTeacherDTOOut updatedSubject = new SubjectTeacherDTOOut()
            {
                Subject = Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(subject),
                Teachers = teachersUpdate
            };
            return updatedSubject;
        }
    }
}