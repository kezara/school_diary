using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class TeachesDTOOut
    {
        public string SubjectName { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
    }
}