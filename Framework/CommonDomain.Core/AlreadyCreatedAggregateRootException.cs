using System;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    public class AlreadyCreatedAggregateRootException : Exception
    {
        public AlreadyCreatedAggregateRootException()
        {
        }

        public AlreadyCreatedAggregateRootException(string message)
            : base(message)
        {
        }

        public AlreadyCreatedAggregateRootException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AlreadyCreatedAggregateRootException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}