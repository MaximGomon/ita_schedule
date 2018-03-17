using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Shedule.IntIta.EmailNotification
{
    public class EmailMessage
    {
        SmtpClient client = new SmtpClient("smtp.gmail.com",587);// this info should be saved in config file
         
        

    }
}
