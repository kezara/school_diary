using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class StudentDepartmentDTOenrolled
    {
        public int StudentDepartmentId { get; set; }
        public StudentDTOIn Student { get; set; }
        public DepartmentDTOStudent Department { get; set; }
        public GradeDTOOut Grade { get; set; }
    }
}