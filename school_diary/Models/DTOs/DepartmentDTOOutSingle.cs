using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class DepartmentDTOOutSingle
    {
        public DepartmentDTOStudent Department { get; set; }
        public GradeDTO Grade { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
    }
}