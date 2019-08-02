using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class SubjectGrade
    {
        public int Id { get; set; }
        public virtual Subject Subjects { get; set; }
        public virtual Grade Grades { get; set; }
        //public virtual ICollection<Teach> Teaches { get; set; }
    }
}