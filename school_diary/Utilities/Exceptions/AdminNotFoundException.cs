using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class AdminNotFoundException : Exception
    {
        public AdminNotFoundException(string message) : base(message)
        {

        }
    }
}