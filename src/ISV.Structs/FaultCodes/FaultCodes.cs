using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISV.Structs
{
    public partial class FaultCodes
    {
        [Fault(Message = "Success", Type = FaultType.Unknown)]
        public const string Success = "IIB0000";
    }
}
