using System;
using System.Runtime.Serialization;

namespace ISV.Structs.Services
{
    [DataContract]
    public class RequestBase
    {
        [DataMember]
        public long ClientId { get; set; }
    }
}
