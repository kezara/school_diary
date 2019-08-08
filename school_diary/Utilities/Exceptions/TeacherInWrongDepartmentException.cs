using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class TeacherInWrongDepartmentException : Exception
    {
        public TeacherInWrongDepartmentException(string message) : base(message)
        {

        }
    }
}