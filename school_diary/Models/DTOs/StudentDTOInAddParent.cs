using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class StudentDTOInAddParent
    {
        public string StudentID { get; set; }
        public IEnumerable<string> ParentID { get; set; }
    }
}