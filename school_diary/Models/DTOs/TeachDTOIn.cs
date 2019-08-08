using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class TeachDTOIn
    {
        public int SubjectID { get; set; }
        public string TeacherID { get; set; }
        public int StudentDepartmentID { get; set; }
    }
}