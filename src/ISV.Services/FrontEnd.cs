using ISV.Services.Contracts.FrontEnd;
using System.ServiceModel;

namespace ISV.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public partial class FrontEnd : IFrontEnd { }
}
