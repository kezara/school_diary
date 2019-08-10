using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class GradeDTOOutGet
    {
        public int Id { get; set; }
        public int GradeYear { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
        public IEnumerable<DepartmentDTOStudent> Departments { get; set; }
    }
}