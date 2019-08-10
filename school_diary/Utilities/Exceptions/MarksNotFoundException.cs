using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class MarksNotFoundException : Exception
    {
        public MarksNotFoundException(string message) : base(message)
        {

        }
    }
}