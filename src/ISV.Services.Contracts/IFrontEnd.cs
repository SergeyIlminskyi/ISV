using System;
using System.ServiceModel;

namespace ISV.Services.Contracts
{
    [ServiceContract]
    public interface IFrontEnd
    {
        [OperationContract]
        void Test();
    }
}
