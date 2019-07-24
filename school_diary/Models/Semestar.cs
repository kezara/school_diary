using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Semestar
    {
        public int Id { get; set; }
        public int SemestarYear { get; set; }
        public ClassRoom ClassRooms { get; set; }
        public Subject Subjects { get; set; }
    }
}