using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class SubjectTEacherDTOIn
    {
        public int SubjectID { get; set; }
        public IEnumerable<string> TeacherID { get; set; }
    }
}