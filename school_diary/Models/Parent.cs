using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Parent : AppUser
    {

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}