using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class StudentDTOInClass
    {
        public string UserName { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public string MotherUserName { get; set; }
        public string FatherUserName { get; set; }
    }
}