using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class TeacherDontTeachThisSubjectException : Exception
    {
        public TeacherDontTeachThisSubjectException(string message) : base(message)
        {

        }
    }
}