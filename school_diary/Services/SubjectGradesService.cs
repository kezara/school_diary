using school_diary.Models;
using school_diary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class SubjectGradesService : ISubjectGradesService
    {
        IUnitOfWork db;
        public SubjectGradesService(IUnitOfWork db)
        {
            this.db = db;
        }

        //IEnumerable<SubjectGrade> GetSubjectGrades(int gradeId)
        //{
        //    return db.SubjectGradesRepository.Get(filter: x => x.Grade.Id == gradeId);
        //}
    }
}