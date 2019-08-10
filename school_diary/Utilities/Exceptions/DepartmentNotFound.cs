using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class DepartmentNotFound : Exception
    {
        public DepartmentNotFound(string message) : base(message)
        {

        }
    }
}