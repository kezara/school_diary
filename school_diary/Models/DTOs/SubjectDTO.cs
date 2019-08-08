using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int SubjectFond { get; set; }
    }
}