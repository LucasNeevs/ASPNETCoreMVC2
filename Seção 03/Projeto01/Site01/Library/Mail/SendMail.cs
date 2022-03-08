using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Site01.Models;
using System.Net;
using System.Net.Mail;

namespace Site01.Library.Mail
{
    public class SendMail
    {
        public readonly static string FromTo = "lucasneves.dev@gmail.com";
        public readonly static string ToFrom = "lucasneves.dev@gmail.com";
        public readonly static string MessageSubject = "This is a test";
        public readonly static string MessageBody = "<h2>Hello my friend! I'm a message coming from C#</h2>";

        public static void SendContactMessage (Contact contact)
        {
            // Mail message
            MailMessage message = new MailMessage();

            string content = string.Format(
                "Name: {0}<br /> Email: {1}<br /> Description: {2}<br /> Message: {3}",
                contact.Name, contact.Email, contact.Description, contact.Message
            );

            message.From = new MailAddress("lucasneves.dev@gmail.com");
            message.To.Add("lucasneves.dev@gmail.com");
            message.Subject = "This is a test";
            message.Body = "<h2>Hello my friend! I'm a message coming from C#</h2>" + content;

            message.IsBodyHtml = true;

            // Configuring SMTP server
            using (SmtpClient smtp = new SmtpClient(Constants.SMTPServer, Constants.SMTPPort))
            {
                smtp.Credentials = new NetworkCredential(Constants.User, Constants.Password);
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}
