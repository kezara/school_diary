using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Teach
    {
        public int Id { get; set; }
        public int Fond { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Teacher> Teachers { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Subject> Subjects { get; set; }
    }
}