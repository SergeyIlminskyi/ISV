
namespace ISV.Structs
{
    public class ClientInfo
    {
        public long Id { get; set; }

        public string PhoneNumber { get; set; }

        public ClientStatus Status { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }



    }


    public enum ClientStatus
    {
    }

}
