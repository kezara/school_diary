using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int GradeYear { get; set; }
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubjectGrade> SubjectGrades { get; set; }
    }
}