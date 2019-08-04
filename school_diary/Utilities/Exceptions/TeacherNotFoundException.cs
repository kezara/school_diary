using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException(string message) : base(message)
        {

        }
    }
}