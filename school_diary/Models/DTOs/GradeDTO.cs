﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class GradeDTO
    {
        
        public int Id { get; set; }
        
        public int GradeYear { get; set; }
    }
}