using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Department
    {
        public int Id { get; set; }
        //public int Year { get; set; }
        public string DepartmentName { get; set; }
        //[JsonIgnore]
        //public Teacher Teachers { get; set; }
        //public Teach Teaches { get; set; }
        //[JsonIgnore]
        public virtual Grade Grades { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Teach> Teaches { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentDepartment> StudentDepartments { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
    }
}