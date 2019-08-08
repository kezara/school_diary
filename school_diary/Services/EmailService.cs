using school_diary.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace school_diary.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(ParentDTOOut parent, MarkDTOOut mark)
        {
            string subject = $"{mark.Student.FirstName} je dobio ocenu iz predmeta {mark.Subject.SubjectName}";
            StringBuilder emailBody = new StringBuilder();
            emailBody.AppendLine("Postovana/i,");
            emailBody.AppendLine($"Ucenik {mark.Student.FirstName} {mark.Student.LastName} je dana {mark.Mark.InsertDate} dobio ocenu {mark.Mark.MarkValue}" +
                $" iz predmeta {mark.Subject.SubjectName}, kod nastavnika {mark.Teacher.FirstName} {mark.Teacher.LastName}");
            emailBody.AppendLine("Srdacan pozdrav,");
            emailBody.AppendLine("Skola");
            string body = emailBody.ToString();
            string FromMail = ConfigurationManager.AppSettings["username"];
            string emailTo = $"{parent.Email}";
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