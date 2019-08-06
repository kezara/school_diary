using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models.DTOs
{
    public class AppUserDTOPassword
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}