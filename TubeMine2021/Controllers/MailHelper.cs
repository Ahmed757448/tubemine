using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Tubemine2020.Controllers
{
    public class MailHelper
    {

        public MailHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void SendMail(string fromAddress, string toAddress, string mailSubject, string mailBody)
        {
            MailMessage mail = new MailMessage();

            MailMessage mailMsg = new MailMessage(fromAddress, toAddress, mailSubject, mailBody);
            mailMsg.IsBodyHtml = true;

            mailMsg.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("do-not-reply@tubemine.net", "Oowp8@130al_L03n");
            smtp.Host = "durham.specialservers.com";
            smtp.EnableSsl = false;
            smtp.Port = 25;


            smtp.Send(mailMsg);
        }

    }

    
}