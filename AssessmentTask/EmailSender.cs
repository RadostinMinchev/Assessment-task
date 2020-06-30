using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace AssessmentTask
{
    static class EmailSender
    {
        public static void SendEmail(string emailSender, string senderPassword, string emailReciever, string filePath)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(emailSender);
                mail.To.Add(emailReciever);
                mail.Subject = "CSV file attached";

                System.Net.Mail.Attachment attachment;
                attachment = new Attachment(filePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emailSender, senderPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
