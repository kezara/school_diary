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
        public GradeService(IUnitOfWork db)
        {
            this.db = db;
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
    }
}