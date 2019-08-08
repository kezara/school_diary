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
        public int Id { get; set; }
        public DateTime? EnrolmentTime { get; set; }
        [NotMapped]
        public string StudentID { get; set; }
        public virtual Student Students { get; set; }
        [NotMapped]
        public int? DepartmentID { get; set; }
        public virtual Department Departments { get; set; }
        //[NotMapped]
        //public IEnumerable<int> TeachIDs { get; set; }
        [JsonIgnore]
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}