using System.Collections.Generic;
using System.Net.Mail;

namespace Schedule.Intita.EmailNotification
{
    public interface IEmailMessage
    {
        MailMessage CreateEmail(string from, string to, string subject, string body, string[] cc, string[] bcc, List<MailMessageAttachment> attachments);
        

    }
}
