using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class SubjectExistsException : Exception
    {
        public SubjectExistsException(string message) : base (message)
        {

        }
    }
}