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
        Grade GetGradeByID(int id);
        Grade CreateGrade(Grade newGrade);
        Grade UpdateGrade(int id, Grade gradeToUpdt);
        Grade DeleteGrade(int id);
    }
}
