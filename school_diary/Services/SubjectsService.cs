using school_diary.Models;
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
            if (subject == null)
            {
                throw new UserNotFoundException();
            }
            db.SubjectsRepository.Delete(id);
            db.Save();
            return subject;
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return db.SubjectsRepository.Get();
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