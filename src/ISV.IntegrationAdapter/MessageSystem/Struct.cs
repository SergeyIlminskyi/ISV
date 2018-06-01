using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISV.IntegrationAdapter.MessageSystem
{
    public class SendEmailRequest : RequestBase
    {
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string AttachmentFileName { get; set; }

        public DateTime? ValidityPeriod { get; set; }

        public bool IsHtml { get; set; }
    }

    public class ResponseBase
    {

        public string ResponseCode
        {
            get { return Code; }
        }

        public string ResponseText
        {
            get { return Message; }
        }
        public string Message { get; set; }
        public string Code { get; set; }
        public bool IsSuccess
        {
            get { return string.IsNullOrEmpty(Code) || Code == "000"; }
        }

    }

    public class SmsResponse : ResponseBase
    {

    }

    public class SendSmsRequest : RequestBase
    {

        public string Phone;

        public string Message;

        public DateTime? ValidityPeriod;

        public bool ValidityPeriodFieldSpecified;
    }

    public class RequestBase
    {


        public long ClientId { get; set; }

        public string SessionId { get; set; }

        public string Guid { get; set; }

        public string CultureName { get; set; }

    }

}
