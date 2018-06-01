using System;
using System.ServiceModel;
using ISV.Structs.Services;

namespace ISV.Services.Contracts.FrontEnd
{
    public partial interface IFrontEnd
    {
        [OperationContract]
        ConfirmEmailRegistrationResponse ConfirmEmailRegistration(ConfirmEmailRegistrationRequest request);

        [OperationContract]
        PrepareEmailRegistrationResponse PrepareEmailRegistration(PrepareEmailRegistrationRequest request);

        [OperationContract]
        PrepareEmailRecoveryPasswordResponse PrepareEmailRecoveryPassword(PrepareEmailRecoveryPasswordRequest request);

        [OperationContract]
        ConfirmEmailRecoveryPasswordResponse ConfirmEmailRecoveryPassword(ConfirmEmailRecoveryPasswordRequest request);

        [OperationContract]
        LogOnResponse LogOn(LogOnRequest request);

        [OperationContract]
        LogOffResponse LogOff(LogOffRequest request);
    }
}
