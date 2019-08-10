using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class DepartmentDTOCreated
    {
        public int Id { get; set; }
       
        public string DepartmentName { get; set; }

        public GradeDTO Grade { get; set; }

    }
}