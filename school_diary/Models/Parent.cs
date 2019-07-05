using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string Email { get; set; }
        //public virtual User Parents { get; set; }
        //public int? ParentID { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Student> Students { get; set; }
    }
}