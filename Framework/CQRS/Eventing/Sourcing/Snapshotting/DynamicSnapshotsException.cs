using System;
using System.Runtime.Serialization;

namespace Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot
{
    [Serializable]
    public class DynamicSnapshotException : Exception
    {
        public DynamicSnapshotException()
        {

        }
        public DynamicSnapshotException(string message, Exception inner)
            : base(message, inner)
        {

        }
        public DynamicSnapshotException(string message)
            : base(message)
        {

        }

        protected DynamicSnapshotException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
