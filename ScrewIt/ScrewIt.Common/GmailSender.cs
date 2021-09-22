using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ScrewIt.Common
{
    public class GmailSender
    {
        public static void SendGmail(string recipient, string subject, string htmlMessage)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("maytrymailsender@gmail.com", "maytrymailsender123")
            };


            string from = "maytrymailsender@gmail.com";

            email.Send(from, recipient, subject, htmlMessage);
        }

    }
}
}
