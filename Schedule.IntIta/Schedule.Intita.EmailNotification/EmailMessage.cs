﻿using System;
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
                if(cc != null)
                foreach (var link in cc)
                {
                    msg.CC.Add(link);
                }
                if(bcc != null)
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
            catch(Exception ex)
            {
                throw new ArgumentException("Message has not been sent");
            }

        }
        

    }

}
