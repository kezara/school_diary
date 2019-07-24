using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    public interface IGradesService
    {
        IEnumerable<Grade> GetAllGrades();
        //IEnumerable<Grade> GetGradeByStudentUserName(string username);
        //IEnumerable<Grade> GetGradeByStudentName(string name);
        //IEnumerable<Grade> GetGradeByStudentLastName(string lastName);
        //IEnumerable<Grade> GetGradeByStudentNameSurname(string name, string surname);
        //IEnumerable<Grade> GetGradeByStudentNameSurnameParentName(string name, string surname, string parentName);
        Grade CreateGrade(Grade newGrade);
        //Grade UpdateGrade(string username, Grade gradeToUpdt);
        //Grade DeleteGrade(string username);
    }
}
