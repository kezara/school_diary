using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class MarkDTO
    {
        public TeachesDTOOut Teaches { get; set; }
        public int MarkValue { get; set; }
    }
}