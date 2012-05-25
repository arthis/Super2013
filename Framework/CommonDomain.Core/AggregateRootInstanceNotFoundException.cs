using System;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    public class AggregateRootInstanceNotFoundException : Exception
    {
        public AggregateRootInstanceNotFoundException()
        {
        }

        public AggregateRootInstanceNotFoundException(string message)
            : base(message)
        {
        }

        public AggregateRootInstanceNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AggregateRootInstanceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}