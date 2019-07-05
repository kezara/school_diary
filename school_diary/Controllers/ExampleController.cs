using school_diary.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace school_diary.Controllers
{
    public class ExampleController : ApiController
    {
        //IExampleService exampleService;

        //public ExampleController(IExampleService exampleService)
        //{
        //    this.exampleService = exampleService;
        //}

        public void PostSendMail()
        {
            string subject = "Testing testing";
            string body = "Pozdrav sa casa ;)";
            string FromMail = ConfigurationManager.AppSettings["username"];
            string emailTo = "borisav.ignjatov@gmail.com";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"]);
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            SmtpServer.Port = int.Parse(ConfigurationManager.AppSettings["smtpPort"]);
            SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            SmtpServer.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["smtpSsl"]);
            SmtpServer.Send(mail);
        }
    }
}
