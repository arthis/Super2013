using System;
using System.Runtime.Serialization;

namespace Cqrs.Domain.Storage
{
    [Serializable]
    public class AggregateRootCreationException : Exception
    {
        public AggregateRootCreationException(string message) : base(message) { }
        public AggregateRootCreationException(string message, Exception inner) : base(message, inner) { }
        protected AggregateRootCreationException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context) { }
    }
}
