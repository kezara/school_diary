using school_diary.Models;
using school_diary.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    public interface IGradeService
    {
        IEnumerable<GradeDTOOutGet> GetGrades();
        GradeDTOOutGet GetGradesById(int id);
        Grade GetGradeId(int id);
        GradeDTO CreateGrade(GradeDTO newGrade);
        GradeDTOOut AddSubjectToGrade(int id, GradeSubjectDTOIn gradeSubject);

        GradeDTO DeleteGrade(int id);
    }
}
