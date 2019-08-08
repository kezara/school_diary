using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class SubjectNotFoundException : Exception
    {
        public SubjectNotFoundException(string message) : base(message)
        {

        }
    }
}