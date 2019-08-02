using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class AdminDTOOut
    {
        [Display(Name = "AdminId")]
        public string Id { get; set; }
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }
    }
}