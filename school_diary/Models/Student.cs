using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Student : AppUser
    {
        
        public virtual StudentDepartment StudentDepartments { get; set; }
        //public IEnumerable<string> ParentID { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Parent> Parents { get; set; }
    }
}