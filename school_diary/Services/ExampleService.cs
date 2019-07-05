using school_diary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class ExampleService : IExampleService
    {
        IUnitOfWork db;

        public ExampleService(IUnitOfWork db)
        {
            this.db = db;
        }
    }
}