using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class DepartmentDTOOut
    {
        public DepartmentDTOStudent Department { get; set; }
        public GradeDTO Grade { get; set; }
    }
}