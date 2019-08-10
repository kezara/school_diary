using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class GradeDepartmentDTOIn
    {
        public int GradeID { get; set; }
        public IEnumerable<int> DepartmentID { get; set; }
    }
}