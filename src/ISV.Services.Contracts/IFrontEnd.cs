using System;
using System.ServiceModel;

namespace ISV.Services.Contracts
{
    [ServiceContract]
    public partial interface IFrontEnd
    {
        [OperationContract]
        void Test();
    }
}
