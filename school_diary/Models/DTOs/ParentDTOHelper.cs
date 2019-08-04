using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class ParentDTOHelper
    {
        public ParentDTOOut Parent { get; set; }
        public IEnumerable<StudentDTOOutParent> Student { get; set; }
    }
}