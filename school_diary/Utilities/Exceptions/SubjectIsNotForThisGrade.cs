﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Utilities.Exceptions
{
    public class SubjectIsNotForThisGrade : Exception
    {
        public SubjectIsNotForThisGrade(string message) : base(message)
        {

        }
    }
}