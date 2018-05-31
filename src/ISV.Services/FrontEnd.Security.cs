
using ISV.Structs.Servises;

namespace ISV.Services
{
    public partial class FrontEnd
    {
        public ConfirmEmailRegistrationResponse ConfirmEmailRegistration(ConfirmEmailRegistrationRequest request)
        {
            return new ConfirmEmailRegistrationResponse();
        }

        public PrepareEmailRegistrationResponse PrepareEmailRegistration(PrepareEmailRegistrationRequest request)
        {
            return new PrepareEmailRegistrationResponse();
        }

        public PrepareEmailRecoveryPasswordResponse PrepareEmailRecoveryPassword(PrepareEmailRecoveryPasswordRequest request)
        {
            return new PrepareEmailRecoveryPasswordResponse();
        }

        public ConfirmEmailRecoveryPasswordResponse ConfirmEmailRecoveryPassword(ConfirmEmailRecoveryPasswordRequest request)
        {
            return new ConfirmEmailRecoveryPasswordResponse();
        }

        public LogOnResponse LogOn(LogOnRequest request)
        {
            return new LogOnResponse();
        }

        public LogOffResponse LogOff(LogOffRequest request)
        {
            return new LogOffResponse();
        }
    }
}
