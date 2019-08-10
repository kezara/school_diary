using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class DepartmentDTOUpdateOut
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public GradeDTO Grade { get; set; }
    }
}