using System;
using System.Runtime.Serialization;

namespace ISV.Structs.Services
{
    [DataContract]
    public class ResponseBase
    {
        [DataMember]
        public string ResponseCode { get; set; }

        [DataMember]
        public string ResponseText { get; set; }
    }
}
