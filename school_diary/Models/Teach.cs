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
        public int WeeklyFond { get; set; }
        public virtual Teacher Teachers { get; set; }
        //za unos i izmenu podataka
        //[NotMapped]
        //public string TeacherUserName { get; set; }
        ////za unos i izmenu podataka
        //[NotMapped]
        //public int SubjectID { get; set; }
        public Grade Grades { get; set; }
        public virtual Subject Subjects { get; set; }
        [JsonIgnore]
        public ICollection<TeachClass> TeachClasses { get; set; }
        //public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
        //[ForeignKey("Students")]
        //public Student Students { get; set; }
        ////[JsonIgnore]
        ////public virtual ICollection<Grade> Grades { get; set; }
        //[ForeignKey("ClassRooms")]
        //public virtual ClassRoom ClassRooms { get; set; }
    }
}