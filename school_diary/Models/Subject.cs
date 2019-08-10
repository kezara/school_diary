using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public int SubjectFond { get; set; }
        [JsonIgnore]
        public virtual ICollection<Teach> Teaches { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
               
        public virtual ICollection<Grade> Grades { get; set; }
    }
}