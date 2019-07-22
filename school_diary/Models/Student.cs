using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Student : AppUser
    {
        //public int? StudentID { get; set; }
        public virtual ClassRoom ClassRooms { get; set; }
        //[NotMapped]
        //public int? ClassRoomID { get; set; }
        public virtual Teach Teachs { get; set; }
        //[NotMapped]
        //public int? TeachsID { get; set; }
        //public virtual Subject Subjects { get; set; }
        //[NotMapped]
        //public int? SubjectID { get; set; }
        //public virtual Teacher Teachers { get; set; }
        //[NotMapped]
        //public string TeacherUN { get; set; }
        [JsonIgnore]
        public ICollection<Grade> Grades { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Parent> Parents { get; set; }
    }
}