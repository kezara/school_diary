using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Teacher : AppUser
    {
        [JsonIgnore]
        public virtual ICollection<Teach> Teachs { get; set; }
        //[JsonIgnore]
        public virtual Student Students { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}