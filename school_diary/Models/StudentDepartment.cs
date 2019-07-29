using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class StudentDepartment
    {
        public int Id { get; set; }
        public DateTime EnrolmentTime { get; set; }
        [JsonIgnore]
        public virtual Student Students { get; set; }
        public virtual Department Departments { get; set; }
        [JsonIgnore]
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}