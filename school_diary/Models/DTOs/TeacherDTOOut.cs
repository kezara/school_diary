using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class TeacherDTOOut
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public IEnumerable<SubjectDTO> Subjects { get; set; }
        public IEnumerable<DepartmentDTO> Departments { get; set; }
        //public IEnumerable<GradeDTOOut> Grades { get; set; }
    }
}