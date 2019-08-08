using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class SubjectTeacherDTOOut
    {
        public SubjectDTO Subject { get; set; }
        public IEnumerable<TeacherDTOOutReg> Teachers { get; set; }
    }
}