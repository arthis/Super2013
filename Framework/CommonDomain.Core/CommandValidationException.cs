using System;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    public class CommandValidationException : Exception
    {
        public CommandValidationException()
        {
        }

        public CommandValidationException(string message)
            : base(message)
        {
        }

        public CommandValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CommandValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}