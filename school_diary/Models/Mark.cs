using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Mark
    {
        public int Id { get; set; }
        //public DateTime GradeDate { get; set; }
        [Range(1,5, ErrorMessage ="Ocena ne moze biti manja od 1, ni veca od 5!!!")]
        public int MarkValue { get; set; }
        //[JsonIgnore]
        public virtual Teach Teaches { get; set; }
        //public virtual Student Students { get; set; }
        //public virtual Teach Teaches { get; set; }
        //public DateTime InsertTime { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Subject> Subjects { get; set; }
        //[JsonIgnore]
        //public virtual Student Students { get; set; }
        //[NotMapped]
        //public string StudentUserName { get; set; }
        //public virtual Subject Subjects { get; set; }
        //[NotMapped]
        //public int SubjectID { get; set; }
    }
}