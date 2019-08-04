﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int GradeYear { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectFond { get; set; }
    }
}