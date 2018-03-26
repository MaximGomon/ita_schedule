using System;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Schedule.Intita.EmailNotification
{
    public class EmailMessage : IEmailMessage
    {
        public MailMessage CreateEmail(string from, string to, string subject, string body, string[] cc, string[] bcc, List<MailMessageAttachment> attachments)
        {
            try
            {
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = subject;
                msg.Body = body;
                foreach (var link in cc)
                {
                    msg.CC.Add(link);
                }
                foreach (var link in bcc)
                {
                    msg.Bcc.Add(link);
                }
                foreach (var attachment in attachments)
                {
                    using (var stream = new MemoryStream())
                    {
                        var bytes = Encoding.UTF8.GetBytes(attachment.Base64String);
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Position = 0;
                        msg.Attachments.Add(new Attachment(stream, attachment.FileName));
                    }
                }
                return msg;
            }
            catch
            {
                throw new ArgumentException("Message has not been sent");
            }

        }
        public void SendMail(MailMessage msg, SmtpClient client)
        {
            try
            {
                client.Send(msg);
            }
            catch (SmtpFailedRecipientsException sfrEx)
            {
                Console.WriteLine("Failed to send : {0}", sfrEx.ToString());
            }
            catch (SmtpException sEx)
            {
                Console.WriteLine("Something went wrong : {0}", sEx.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception causght in MailSend(): {0}", ex.ToString());
            }
        }

    }

}
