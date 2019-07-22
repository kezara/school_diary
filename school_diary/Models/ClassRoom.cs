using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string ClassName { get; set; }
        //[JsonIgnore]
        //public Teacher Teachers { get; set; }
        //public Teach Teaches { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; }
    }
}