using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Parent : AppUser
    {
        public override string Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}