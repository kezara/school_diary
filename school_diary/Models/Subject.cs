using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        //public int Semester { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}