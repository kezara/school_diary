using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class SubjectDTOOut
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int SubjectFond { get; set; }

        public string TeacherName { get; set; }
        public string TeacherLastName { get; set; }
        public string TeacherID { get; set; }

    }
}