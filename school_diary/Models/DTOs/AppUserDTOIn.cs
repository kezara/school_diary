using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class AppUserDTOIn
    {
        [Display(Name = "User Id")]
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string FirstName { get; set; }
        [Display(Name = "User Surname")]
        public string LastName { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "User Role Id")]
        public string RoleId { get; set; }
    }
}