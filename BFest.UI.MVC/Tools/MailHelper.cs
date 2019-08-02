using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BFest.UI.MVC.Tools
{
    public class MailHelper
    {
        public static bool SendConfirmationMail(string email,out int sifreniz)
        {
            Random rnd = new Random();
            int yeniSifre = rnd.Next(1000, 9999);
            sifreniz = yeniSifre;
            bool result = false;

            MailMessage msg = new MailMessage();
            msg.To.Add(email);
            msg.Subject = "BFest Yeni Şifreniz";
            msg.IsBodyHtml = true;
            msg.Body = "Yeni Şifreniz: "+yeniSifre.ToString();
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
            catch (Exception)
            {

                result = false;
            }
            return result;


           
        }
    }
}