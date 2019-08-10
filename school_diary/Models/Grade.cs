using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        [Range(1,8,ErrorMessage ="Grade must be between 1 and 8")]
        public int GradeYear { get; set; }
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; }
        [JsonIgnore]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}