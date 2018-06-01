using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ISV.IntegrationAdapter.MessageSystem
{
    public class Proxy : IProxy
    {

        //SMS params
        private string SMSmailServerHost = String.Empty;
        private int SMSmailServerPort = 25;
        private string SMSmailServerUser = String.Empty;
        private string SMSmailServerPassword = String.Empty;
        private string SMSmailServerDomain = String.Empty;
        private string SMSmailFrom = String.Empty;
        private string SMSMailSuffix = String.Empty;

        private string c = String.Empty;

        //E-mail params
        private string EmailServerHost = String.Empty;
        private int EmailServerPort = 25;
        private string EmailServerUser = String.Empty;
        private string EmailServerPassword = String.Empty;
        private string EmailServerDomain = String.Empty;
        private string EmailFrom = String.Empty;



        public Proxy()
        {

        }

        public ResponseBase SendEmail(SendEmailRequest request)
        {
            //need check
            try
            {
                SendEmail(request.Email, request.Subject, request.Message, request.IsHtml);
                return new ResponseBase() { Code = "000", Message = "Ok" };

            }
            catch (SmtpException smtpEx)
            {
                return new ResponseBase() { Code = "001", Message = smtpEx.Message };
            }
            catch (System.Exception ex)
            {
                return new ResponseBase() { Code = "001", Message = "Error" };
            }
        }

        public SmsResponse SendSms(SendSmsRequest request)
        {
            try
            {
                string mailTo = string.Format("{0}@{1}", request.Phone, SMSMailSuffix);
                SendSms(mailTo, "test", request.Message);
                return new SmsResponse() { Code = "000", Message = "Ok" };
            }
            catch (System.Exception ex)
            {
                return new SmsResponse() { Code = "001", Message = "Error" };
            }
        }

        private void SendSms(string mailTo, string mailSubj, string mailBody)
        {
            string error = String.Empty;
            SmtpClient smtpClient = new SmtpClient(SMSmailServerHost, SMSmailServerPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(SMSmailServerUser, SMSmailServerPassword, SMSmailServerDomain);

            // prepare email
            MailMessage message = new MailMessage();
            message.From = new MailAddress(SMSmailFrom);
            message.To.Add(new MailAddress(mailTo));
            message.IsBodyHtml = false;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = mailBody;
            message.Subject = mailSubj;
            try
            {
                smtpClient.Send(message);
            }
            catch (System.Net.Mail.SmtpFailedRecipientsException ex)
            {
                error = ex.Message;
            }
            catch (System.Exception ex)
            {
                error = ex.Message;
            }
        }

        private void SendEmail(string mailTo, string mailSubj, string mailBody, bool IsHtml)
        {
            string error = String.Empty;

            SmtpClient smtpClient = new SmtpClient(EmailServerHost, EmailServerPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(EmailServerUser, EmailServerPassword, EmailServerDomain);

            // prepare email
            MailMessage message = new MailMessage();
            message.From = new MailAddress(EmailFrom);
            message.To.Add(new MailAddress(mailTo));
            message.IsBodyHtml = IsHtml;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = mailBody;
            message.Subject = mailSubj;
            message.SubjectEncoding = Encoding.UTF8;

            smtpClient.Send(message);
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public string SystemCode
        {
            get { throw new NotImplementedException(); }
        }
    }
}
