using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [NotMapped]
        public int GradeID { get; set; }
        [Required]
        public virtual Grade Grades { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentDepartment> StudentDepartments { get; set; }
    }
}