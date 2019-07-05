using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_diary.Services
{
    public interface IEmailService
    {
        void SendEmail(string emailAddress);
    }
}
