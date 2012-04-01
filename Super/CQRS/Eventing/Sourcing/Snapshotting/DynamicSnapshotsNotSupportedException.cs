using System;
using System.Runtime.Serialization;

namespace Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot
{
    [Serializable]
    public class DynamicSnapshotNotSupportedException : DynamicSnapshotException
    {
        public DynamicSnapshotNotSupportedException()
        {

        }

        public DynamicSnapshotNotSupportedException(string message)
            : base(message)
        {

        }

        protected DynamicSnapshotNotSupportedException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        public DynamicSnapshotNotSupportedException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public Type AggregateType { get; set; }

    }
}