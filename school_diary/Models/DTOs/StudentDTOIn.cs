﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class StudentDTOIn
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Required]
        //public StudentDepartmentDTO Department { get; set; }
        //public IEnumerable<ParentDTO> Parents { get; set; }
    }
}