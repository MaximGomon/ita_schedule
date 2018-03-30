using System;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Schedule.Intita.EmailNotification
{
    public class SmtpBehaviour : ISmtpBehaviour
    {
        private readonly SmtpClient _client;
        public SmtpBehaviour(string server, int port, string yourusername, string yourpassword)
        {
            _client = new SmtpClient(server, port);
            _client.Credentials = new System.Net.NetworkCredential(yourusername, yourpassword);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public SmtpClient GetClient()
        {
            return _client;
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
