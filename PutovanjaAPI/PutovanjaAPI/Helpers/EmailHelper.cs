using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using PutovanjaAPI.Models;

namespace PutovanjaAPI.Helpers
{
    public static class EmailHelper
    {
        public static void PosaljiEmail(Uposlenik u, string subject, TextPart body)
        {
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress(u.Ime + " " + u.Prezime + ": Službeni put", u.Email));
            message.From.Add(new MailboxAddress("Službena putovanja", "putovanja.api@gmail.com"));
            message.Subject = subject;
            message.Body = body;

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, false);
                emailClient.Authenticate("putovanja.api@gmail.com", "putovanja123!");
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }
        }
    }
}
