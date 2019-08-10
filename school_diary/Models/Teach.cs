using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Teach
    {
        public int Id { get; set; }
       
        [NotMapped]
        public string TeacherID { get; set; }
        public virtual Teacher Teachers { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Mark> Marks { get; set; }
        [NotMapped]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
        [NotMapped]
        public int StudentDepartmentID { get; set; }
        public virtual StudentDepartment StudentDepartments { get; set; }
    }
}