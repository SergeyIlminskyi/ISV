using System;

namespace ISV.Structs
{
    public static partial class FaultCodes
    {
        public enum FaultType
        {
            Business,
            Security,
            Unknown
        }

        public enum LogLevel
        {
            None = 0,
            Fatal = 1,
            Error = 2,
            Finance = 3,
            Warning = 4,
            Info = 5,
            Debug = 6,
        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
        public sealed class FaultAttribute : Attribute
        {
            public FaultAttribute()
            {
                LogLevel = LogLevel.Debug;
            }

            public string Message { get; set; }

            public FaultType Type { get; set; }

            public LogLevel LogLevel { get; set; }
        }
    }
}
