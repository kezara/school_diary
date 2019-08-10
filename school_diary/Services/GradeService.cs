using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;

namespace school_diary.Services
{
    public class GradeService : IGradeService
    {
        IUnitOfWork db;
        ISubjectsService subjectsService;
        public GradeService(IUnitOfWork db, ISubjectsService subjectsService)
        {
            this.db = db;
            this.subjectsService = subjectsService;
        }

        public IEnumerable<GradeDTOOutGet> GetGrades()
        {
            IEnumerable<Grade> grades = db.GradesRepository.Get();
            if (grades == null)
            {
                throw new GradesNotFoundException("No grades here");
            }
            var gradesDTO = grades.Select(x => Utilities.ConverterDTO.GradeDTOConverter(x));

            return gradesDTO;
        }

        public GradeDTO CreateGrade(GradeDTO newGrade)
        {
            Grade grade = Utilities.ConverterDTO.SimpleDTOConverter<Grade>(newGrade);
            db.GradesRepository.Insert(grade);
            db.Save();
            return newGrade;
        }

        public GradeDTOOutGet GetGradesById(int id)
        {
            Grade grade = db.GradesRepository.Get(filter: x => x.Id == id).FirstOrDefault();
            if (grade == null)
            {
                throw new GradesNotFoundException($"No grade with id {id} here");
            }
            var gradesDTO = Utilities.ConverterDTO.GradeDTOConverter(grade);

            return gradesDTO;
        }

        public Grade GetGradeId(int id)
        {
            Grade grade = db.GradesRepository.Get(filter: x => x.Id == id).FirstOrDefault();
            if (grade == null)
            {
                throw new GradesNotFoundException($"No grade with id {id} here");
            }

            return grade;
        }

        public GradeDTOOut AddSubjectToGrade(int id, GradeSubjectDTOIn gradeSubject)
        {
            Grade grade = GetGradeId(id);
            HashSet<Subject> subjects = new HashSet<Subject>();
            foreach (var ID in gradeSubject.SubjectID)
            {
                var subject = subjectsService.GetSubjectByID(ID);
                subjects.Add(subject);
            }

            grade.Subjects = subjects;
            db.GradesRepository.Update(grade);

            IEnumerable<SubjectDTO> subjectDTO = subjects.Select(x => Utilities.ConverterDTO.SimpleDTOConverter<SubjectDTO>(x));

            GradeDTOOut gradeDTO = new GradeDTOOut()
            {
                Id = grade.Id,
                GradeYear = grade.GradeYear,
                Subjects = subjectDTO
            };
            return gradeDTO;
        }

        public GradeDTO DeleteGrade(int id)
        {
            Grade grade = db.GradesRepository.GetByID(id);
            if (grade == null)
            {
                throw new GradesNotFoundException($"No grade wuth id {id}");
            }
            db.GradesRepository.Delete(id);
            db.Save();

            GradeDTO gradeDTO = Utilities.ConverterDTO.SimpleDTOConverter<GradeDTO>(grade);

            return gradeDTO;
        }
    }
}