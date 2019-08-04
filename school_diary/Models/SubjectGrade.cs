using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class SubjectGrade
    {
        public int Id { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }
    }
}