using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BookStore.CODE.KhachHang
{
    public class SendMail
    {
        static String SendMailFrom = "caohuuhieu12b8@gmail.com";
        public static bool sendMail(string sendMailTo, string sendMailSubject, string sendMailBody)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage email = new MailMessage();
                // START
                email.From = new MailAddress(SendMailFrom);
                email.To.Add(sendMailTo);
                email.CC.Add(SendMailFrom);
                email.Subject = sendMailSubject;
                email.Body = sendMailBody;
                //END
                //SmtpServer.Timeout = 5000;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "qqprvddzgcwzxbiz");
                SmtpServer.Send(email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}