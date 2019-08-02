﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class StudentDTOOutSingle
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public int Grade { get; set; }
        public IEnumerable<SubjectDTOOut> Subjects { get; set; }
        //public IEnumerable<TeachesDTOOut> Teaches { get; set; }
        public DateTime? EnrolmentTime { get; set; }
        public IEnumerable<ParentDTOOut> Parents { get; set; }
    }
}