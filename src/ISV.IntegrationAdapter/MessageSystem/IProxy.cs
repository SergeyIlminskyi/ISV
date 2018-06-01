using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISV.IntegrationAdapter.MessageSystem
{
    public interface IProxy
    {
        ResponseBase SendEmail(SendEmailRequest request);
        SmsResponse SendSms(SendSmsRequest request);
    }
}
