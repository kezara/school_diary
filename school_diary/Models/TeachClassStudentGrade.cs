using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class TeachClassStudentGrade
    {
        public int Id { get; set; }
        public TeachClassStudent TeachClassStudents { get; set; }
        public Grade Grades { get; set; }
    }
}