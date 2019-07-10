using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        //public virtual User Teachers { get; set; }
        [NotMapped]
        public int? TeacherID { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Teach> Teaches { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Grade> Grades { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}