using System;
using System.Net.Mail;

namespace Schedule.Intita.EmailNotification
{
    public interface ISmtpBehaviour : IDisposable
    {
        SmtpClient GetClient();
        void SendMail(MailMessage msg, SmtpClient client);
    }
}
