﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Student
    {
        public int Id { get; set; }
        public virtual User Students { get; set; }
        //public int? StudentID { get; set; }
        //public virtual ClassRoom ClassRoom { get; set; }
        //public int? ClassRoomID { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Grade> Grades { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Parent> Parents { get; set; }
    }
}