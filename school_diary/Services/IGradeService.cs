using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    interface IGradeService
    {
        IEnumerable<Grade> GetGradeSubjects(int gradeId);
    }
}
