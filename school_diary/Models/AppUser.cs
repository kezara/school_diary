using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public abstract class AppUser : IdentityUser
    {
        // public int Id { get; set; }
        // public string Username { get; set; }
        //public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
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