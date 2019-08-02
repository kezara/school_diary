using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message)
        {

        }
    }
}