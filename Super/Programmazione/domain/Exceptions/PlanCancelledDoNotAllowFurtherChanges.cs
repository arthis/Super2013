using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class PlanCancelledDoNotAllowFurtherChanges : Exception
    {
        public PlanCancelledDoNotAllowFurtherChanges()
        {
        }

        public PlanCancelledDoNotAllowFurtherChanges(string message)
            : base(message)
        {
        }

        public PlanCancelledDoNotAllowFurtherChanges(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public PlanCancelledDoNotAllowFurtherChanges(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public bool Equals(PlanCancelledDoNotAllowFurtherChanges other)
        {
            return !ReferenceEquals(null, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(PlanCancelledDoNotAllowFurtherChanges)) return false;
            return Equals((PlanCancelledDoNotAllowFurtherChanges)obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}