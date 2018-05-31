using System;
using System.Runtime.Serialization;

namespace ISV.Structs.Services
{
    [DataContract]
    public class ResponseBase
    {
        public ResponseBase()
        {
            Code = FaultCodes.Success;
        }
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        public bool IsSuccess
        {
            get
            {
                return String.IsNullOrEmpty(Code) || Code == FaultCodes.Success;
            }
        }
    }
}
