using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using school_diary.Models;
using school_diary.Repositories;

namespace school_diary.Services
{
    public class GradeService : IGradeService
    {
        IUnitOfWork db;
        public GradeService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<Grade> GetGradeSubjects(int gradeId)
        {
            IEnumerable<Grade> subjects = db.GradesRepository.Get(x => x.Id == gradeId);
            return subjects;
        }
    }
}