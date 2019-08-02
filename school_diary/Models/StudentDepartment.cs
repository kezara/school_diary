using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class StudentDepartment
    {
        public int? Id { get; set; }
        public DateTime? EnrolmentTime { get; set; }
        //[ForeignKey("Students_Id")]
        public virtual Student Students { get; set; }
        //[ForeignKey("Departments_Id")]
        //[NotMapped]
        //public string Department_Id { get; set; }
        public virtual Department Departments { get; set; }
        [JsonIgnore]
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}