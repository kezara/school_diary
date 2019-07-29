using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class StudentDTOOutClass
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public string MotherUserName { get; set; }
        public string MotherName { get; set; }
        public string MotherSurname { get; set; }
        public string FatherUserName { get; set; }
        public string FatherName { get; set; }
        public string FatherSurname { get; set; }
    }
}