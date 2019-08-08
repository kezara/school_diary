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
        IEnumerable<GradeDTOOut> GetGrades();
    }
}
