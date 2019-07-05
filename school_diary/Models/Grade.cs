using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string GradeDesc { get; set; }
        public int GradeValue { get; set; }
        //[JsonIgnore]
        //public virtual Teacher Teachers { get; set; }
        //[JsonIgnore]
        //public virtual Student Students { get; set; }
    }
}