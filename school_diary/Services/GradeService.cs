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

        public IEnumerable<GradeDTOOut> GetGrades()
        {
            IEnumerable<Grade> grades = db.GradesRepository.Get();
            if (grades == null)
            {
                throw new GradesNotFoundException("No grades here");
            }
            var gradesDTO = grades.Select(x => Utilities.ConverterDTO.GradeDTOConverter(x));

            return gradesDTO;
        }
    }
}