using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class MarkDTOOut
    {
        public StudentDTO Student { get; set; }
        public TeacherDTO Teacher { get; set; }
        public SubjectDTO Subject { get; set; }
        public MarkDTODate Mark { get; set; }
    }
}