using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class ScenarioCancelledDoNotAllowFurtherChanges : Exception
    {
         public ScenarioCancelledDoNotAllowFurtherChanges()
		{
		}

		public ScenarioCancelledDoNotAllowFurtherChanges(string message)
			: base(message)
		{
		}

		public ScenarioCancelledDoNotAllowFurtherChanges(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public ScenarioCancelledDoNotAllowFurtherChanges(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

        public bool Equals(ScenarioCancelledDoNotAllowFurtherChanges other)
        {
            return !ReferenceEquals(null, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ScenarioCancelledDoNotAllowFurtherChanges)) return false;
            return Equals((ScenarioCancelledDoNotAllowFurtherChanges) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}