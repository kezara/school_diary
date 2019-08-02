using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class TeachesDTOOut
    {
        public int Id { get; set; }
        public TeacherDTOOut Teacher { get; set; }
        public SubjectGradeDTOOut SubjectGrade { get; set; }

    }
}