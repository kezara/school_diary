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

        //public Grade DeleteGrade(string username)
        //{
        //    Grade grade = GetGradeByStudentUserName(username);
        //    if (grade == null)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    db.GradesRepository.Delete(username);
        //    db.Save();
        //    return grade;
        //}

        public IEnumerable<Grade> GetAllGrades()
        {
            return db.GradesRepository.Get();
        }

        //public IEnumerable<Grade> GetGradeByStudentUserName(string username)
        //{
        //    IEnumerable<Grade> grade = db.GradesRepository.Get(filter: x => x.
        //    if (grade.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return grade;
        //}

        //public IEnumerable<Grade> GetGradeByStudentName(string name)
        //{
        //    IEnumerable<Grade> grade = db.GradesRepository.Get(filter: x => x.T
        //    if (grade.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return grade;
        //}

        //public IEnumerable<Grade> GetGradeByStudentLastName(string lastName)
        //{
        //    IEnumerable<Grade> grade = db.GradesRepository.Get(filter: x => x.Teaches.Students.LastName == lastName);
        //    if (grade.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return grade;
        //}

        //public IEnumerable<Grade> GetGradeByStudentNameSurname(string name, string surname)
        //{
        //    IEnumerable<Grade> grade = db.GradesRepository.Get(filter: x => x.Teaches.Students.FirstName == name && x.Teaches.Students.LastName == surname);
        //    if (grade.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return grade;
        //}

        /***********************************
        * ovo mozda moze da se resi sa DTO *
        ***********************************/
        //public IEnumerable<Grade> GetGradeByStudentNameSurnameParentName(string name, string surname, string parentName)
        //{
        //    IEnumerable<Grade> grade = db.GradesRepository.Get(filter: x => x.Students.FirstName == name && x.Students.LastName == surname && x.Students.Parents.Any(parentName));

        //    if (grade.Count() < 1)
        //    {
        //        throw new UserNotFoundException();
        //    }
        //    return grade;
        //}

        //public Grade UpdateGrade(string username, Grade gradeToUpdt)
        //{
        //    Grade grade = db.GradesRepository.Get(filter: x => x.Teaches.Students.UserName == username && x.GradeValue == gradeToUpdt.GradeValue && x.Id == gradeToUpdt.Id).FirstOrDefault();

        //    //grade.Id = gradeToUpdt.Id;
        //    ////grade.GradeDesc = gradeToUpdt.GradeDesc;
        //    //grade.GradeValue = gradeToUpdt.GradeValue;
        //    //db.GradesRepository.Update(grade);
        //    db.Save();
        //    return gradeToUpdt;
        //}
    }
}