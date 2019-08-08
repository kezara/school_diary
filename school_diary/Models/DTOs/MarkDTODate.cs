using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class MarkDTODate
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public int MarkValue { get; set; }
    }
}