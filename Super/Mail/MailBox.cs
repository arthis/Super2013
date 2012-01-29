using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dart.PowerTCP.Mail;
using System.Configuration;
using System.IO;


namespace Mail
{
    public class MailBox : ISendMessage
    {
        string imapServer = ConfigurationManager.AppSettings["ImapServer"];
        string smtpServerPec = ConfigurationManager.AppSettings["SmtpServer"];
        string SmtpServerUser = ConfigurationManager.AppSettings["SmtpServerUser"];
        string PasswordSmtpPassword = ConfigurationManager.AppSettings["PasswordSmtpPassword"];

        private void SmtpCertificateReceived(object sender, Dart.PowerTCP.Mail.CertificateReceivedEventArgs e)
        {
            //accept it anyway
            e.Accept = true;
        }

        private void SmtpTrace(object sender, SegmentEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Segment.ToString());
        }

        public void SendMessage(string from, string to, string oggetto, string filename, byte[] allegato)
        {
            MessageStream message = new MessageStream()
            {
                From = new MailAddress(SmtpServerUser),
                To = new MailAddresses() { new MailAddress(to) },
                Subject = oggetto
            };

            var m = new MemoryStream(allegato);
            var attach = new MimeAttachmentStream(m, filename, ContentType.TextXml, ContentEncoding.EightBit, "");
            message.Attachments.Add(attach);

            Smtp _smtp = new Smtp
            {
                Server = smtpServerPec,
                ServerPort = 465,
                Username = SmtpServerUser,
                Password = PasswordSmtpPassword,
                Security = Security.Implicit
            };
            _smtp.CertificateReceived += new CertificateReceivedEventHandler(this.SmtpCertificateReceived);
            _smtp.Trace += new SegmentEventHandler(this.SmtpTrace);
            _smtp.Send(message);
        }
    }
}
