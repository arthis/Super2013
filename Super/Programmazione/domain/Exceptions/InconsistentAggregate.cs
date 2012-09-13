using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class InconsistentAggregate : Exception
    {
         public InconsistentAggregate()
		{
		}

		public InconsistentAggregate(string message)
			: base(message)
		{
		}

		public InconsistentAggregate(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public InconsistentAggregate(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

    }
}