using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ITA.Schedule.Util
{
    /// <summary>
    /// Class for save log data
    /// </summary>
    public static class LoggerSchedule
    {

        public static Logger log;


        public static void MakeLog()
        {
            try
            {
                log = LogManager.GetCurrentClassLogger();

                log.Trace("Version: {0}", Environment.Version);
                log.Trace("OS: {0}", Environment.OSVersion);
                log.Trace("Command: {0}", Environment.CommandLine);

                NLog.Targets.FileTarget tar =
                    (NLog.Targets.FileTarget) LogManager.Configuration.FindTargetByName("run_log");
                tar.DeleteOldFileOnStartup = false;
                //throw new System.ArgumentException("Parametr can't be null");
                
            }
            catch (Exception e)
            {
                var message = new MailMessage(
                        @"litvak83@mail.ru",
                        @"viktor.lv.30@gmail.com",
                        @"Exception log report",
                        e.Message);
                //("Error during log working!" + Environment.NewLine + e.Message);

                //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                //// Add credentials if the SMTP server requires them.
                //client.Credentials = CredentialCache.DefaultNetworkCredentials;
                //client.Send(message);
            }

            
        }

    }
}
