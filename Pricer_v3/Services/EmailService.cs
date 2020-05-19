using System.Net;
using System.Net.Mail;

namespace Pricer_v3
{
    public interface IEmailService
    {
        public void Send(string email, string subject, string message);
    }
    public class EmailService : IEmailService
    {
        public void Send(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("pricer.noreply@gmail.com"); 
            mail.To.Add(new MailAddress(email));
            mail.Subject = subject;
            mail.Body = message;

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("pricer.noreply@gmail.com", "eessshyzgibshldy");
                client.Send(mail);
            }
        }
    }
}