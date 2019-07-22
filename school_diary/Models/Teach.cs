using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public virtual Subject Subjects { get; set; }
        //public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        //public virtual ClassRoom ClassRooms { get; set; }
    }
}