using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Teach
    {
        public int Id { get; set; }
        //public int WeeklyFond { get; set; }
        public virtual Teacher Teachers { get; set; }
        //za unos i izmenu podataka
        //[NotMapped]
        //public string TeacherUserName { get; set; }
        ////za unos i izmenu podataka
        //[NotMapped]
        //public int SubjectID { get; set; }
        [JsonIgnore]
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual Subject Subject { get; set; }
        //public virtual ICollection<ClassRoom> Departments { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
        //[ForeignKey("Students")]
        //public Student Students { get; set; }
        //public virtual Department Departments { get; set; }
        public virtual StudentDepartment StudentDepartments { get; set; }
    }
}