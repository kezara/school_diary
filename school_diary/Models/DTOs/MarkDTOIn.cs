using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class MarkDTOIn
    {
        public string TeacherID { get; set; }
        public string StudentID { get; set; }
        public int SubjectID { get; set; }
        public int MarkValue { get; set; }
    }
}