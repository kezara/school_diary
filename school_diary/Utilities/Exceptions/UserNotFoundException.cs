using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException():base("Requested user doesn't exists.")
        {

        }
    }
}