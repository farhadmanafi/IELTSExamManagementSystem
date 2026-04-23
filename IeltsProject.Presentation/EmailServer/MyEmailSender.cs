using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace IeltsProject.Presentation.EmailServer
{
    public class MyEmailSender : IMyEmailSender
    {
        public IConfiguration Configuration { get; }
        public MyEmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void SendEmail(string email, string subject, string HtmlMessage)
        {   
            var message = new MailMessage();
            //message.To.Add(new MailAddress(user.Email));
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("usermanagement@bpvielts.com");  // replace with valid value
            message.Subject = "EmailConfirm"; // "Your email subject";
            message.Body = HtmlMessage; // string.Format(body, model.UserName, model.Email, "asdswef");
            message.IsBodyHtml = true;
            var emailClient = new SmtpClient("mail.bpvielts.com");
            emailClient.UseDefaultCredentials = false;
            var SMTPUserInfo = new System.Net.NetworkCredential("usermanagement@bpvielts.com", "Euurwv9}x7g8");
            emailClient.Credentials = SMTPUserInfo;

            emailClient.Send(message);

            //using (MailMessage mm = new MailMessage("ForgotPassword@bpvielts.com", email))
            //{
            //    mm.Subject = subject;
            //    string body = HtmlMessage;
            //    mm.Body = body;
            //    mm.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "mail.bpvielts.com";
            //    smtp.EnableSsl = true;
            //    NetworkCredential NetworkCred = new NetworkCredential("ForgotPassword@bpvielts.com", "0&.H.!-pL_h]");
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = 587;
            //    smtp.Send(mm);
            //}
        }
    }
}
