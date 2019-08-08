using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class TeacherDontTeachThisDepartment : Exception
    {
        public TeacherDontTeachThisDepartment(string message) : base(message)
        {

        }
    }
}