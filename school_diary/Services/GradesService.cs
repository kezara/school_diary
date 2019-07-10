using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class GradesService : IGradesService
    {
        IUnitOfWork db;
        public GradesService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Grade CreateGrade(Grade newGrade)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.GradesRepository.Insert(newGrade);
            db.Save();
            return newGrade;
        }

        public Grade DeleteGrade(int id)
        {
            Grade grade = GetGradeByID(id);
            if (grade == null)
            {
                throw new UserNotFoundException();
            }
            db.GradesRepository.Delete(id);
            db.Save();
            return grade;
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return db.GradesRepository.Get();
        }

        public Grade GetGradeByID(int id)
        {
            return db.GradesRepository.GetByID(id);
        }

        public Grade UpdateGrade(int id, Grade gradeToUpdt)
        {
            Grade grade = GetGradeByID(id);

            grade.Id = gradeToUpdt.Id;
            grade.GradeDesc = gradeToUpdt.GradeDesc;
            grade.GradeValue = gradeToUpdt.GradeValue;
            db.GradesRepository.Update(grade);
            db.Save();
            return gradeToUpdt;
        }
    }
}