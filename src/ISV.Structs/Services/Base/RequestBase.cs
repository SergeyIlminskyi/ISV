using System;
using System.Runtime.Serialization;

namespace ISV.Structs.Services
{
    [DataContract]
    public class RequestBase
    {

        [DataMember(Order = 0, IsRequired = true)]
        public long ClientId { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public string AppUser { get; set; }

        [DataMember(Order = 2)]
        public string SessionID { get; set; }

        [DataMember(Order = 3)]
        public string SessionHash { get; set; }

        [DataMember(Order = 5)]
        public string HostName { get; set; }

        [DataMember(Order = 6)]
        public string HostAddress { get; set; }

        [DataMember(Order = 7)]
        public string Guid { get; set; }

        public void CopyFrom(RequestBase request)
        {
            ClientId = request.ClientId;
            AppUser = request.AppUser;
            SessionID = request.SessionID;
            SessionHash = request.SessionHash;
            HostName = request.HostName;
            HostAddress = request.HostAddress;
            Guid = request.Guid;
            
        }
    }
}
