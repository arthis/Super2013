using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class ScenarioCancelledDoNotAllowChangingDescription : Exception
    {
         public ScenarioCancelledDoNotAllowChangingDescription()
		{
		}

		public ScenarioCancelledDoNotAllowChangingDescription(string message)
			: base(message)
		{
		}

		public ScenarioCancelledDoNotAllowChangingDescription(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public ScenarioCancelledDoNotAllowChangingDescription(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

        public bool Equals(ScenarioCancelledDoNotAllowChangingDescription other)
        {
            return !ReferenceEquals(null, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ScenarioCancelledDoNotAllowChangingDescription)) return false;
            return Equals((ScenarioCancelledDoNotAllowChangingDescription) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}