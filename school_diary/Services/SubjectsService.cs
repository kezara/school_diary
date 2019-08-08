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
        public SubjectsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Subject CreateSubject(Subject newSubject)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.SubjectsRepository.Insert(newSubject);
            db.Save();
            return newSubject;
        }

        public Subject DeleteSubject(int id)
        {
            Subject subject = GetSubjectByID(id);
            
            db.SubjectsRepository.Delete(id);
            db.Save();
            return subject;
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

            //public IEnumerable<Subject> GetGradesOfSubject(fillter: x => x.Subject.Name)

            public Subject GetSubjectByID(int id)
        {
            return db.SubjectsRepository.GetByID(id);
        }

        public Subject UpdateSubject(int id, Subject subjectToUpdt)
        {
            Subject subject = GetSubjectByID(id);

            subject.Id = subjectToUpdt.Id;
            subject.SubjectName = subjectToUpdt.SubjectName;
            db.SubjectsRepository.Update(subject);
            db.Save();
            return subjectToUpdt;
        }
    }
}