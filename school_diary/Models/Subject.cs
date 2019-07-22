using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        // public int WeeklyFond { get; set; }
        //public int Semester { get; set; }
        //public virtual Teach Fond { get; set; }
        //[NotMapped]
        //public int? FondID { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Student> Students { get; set; }
        [JsonIgnore]
        public virtual ICollection<Teach> Teachs { get; set; }
        [JsonIgnore]
        public ICollection<Grade> Grades { get; set; }
    }
}