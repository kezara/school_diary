using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Teacher> Teacher { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Student> Student { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Parent> Parent { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Admin> Admin { get; set; }
    }
}