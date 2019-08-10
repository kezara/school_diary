using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class GradeSubjectDTOIn
    {
        public int GradeID { get; set; }
        public IEnumerable<int> SubjectID { get; set; }
    }
}