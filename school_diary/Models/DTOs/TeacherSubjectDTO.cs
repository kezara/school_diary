using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class TeacherSubjectDTO
    {
        public SubjectDTO Subject { get; set; }
        public TeacherDTO Teacher { get; set; }
    }
}