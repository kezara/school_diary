﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class SubjectGradeDTOOut
    {
        public int Id { get; set; }
        public SubjectDTO Subject { get; set; }
        public GradeDTOOut Grade { get; set; }
    }
}