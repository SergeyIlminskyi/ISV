using NUnit.Framework;
using ISV.Services.Contracts.FrontEnd;
using ISV.Structs;
using ISV.Structs.Services;
using ISV.Utils;

namespace ISV.Services.Host.Test
{
    partial class FrontEnd
    {
        [Test, Order(1)]
        public void PrepareEmailRegistrationTest()
        {
            var request = new PrepareEmailRegistrationRequest();
            PrepareEmailRegistrationResponse response;

            WCFHelper.Call<IFrontEnd>(service =>
            {
                response = service.PrepareEmailRegistration(request);
                Assert.AreEqual(response.Code, FaultCodes.Success);
            });
        }
    }
}
