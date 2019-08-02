using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace BFest.UI.MVC.Tools
{
    public class MailIcin
    {
        public static bool SendConfirmationMail(string username, string password, string email, int id)
        {
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.To.Add(email);
            msg.Subject = "Hoşgeldiniz ...";
            msg.IsBodyHtml = true;
            msg.Body = "Sitemize hoşgeldiniz,keyifli alışverişler dileriz..";
            msg.From = new MailAddress("bfestfestival@gmail.com");
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("bfestfestival@gmail.com", "123bfest-");
            smtpClient.Credentials = credential;
            try
            {
                smtpClient.Send(msg);
                result = true;
            }
            catch (Exception ex)
            {

                result = false;
            }
            return result;
        }
    }
}