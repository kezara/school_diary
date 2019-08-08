using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class StudentDepartmentDTO
    {
        public DateTime? EnrolmentTime { get; set; }
        public string StudentID { get; set; }
        public int DepartmentID { get; set; }
    }
}