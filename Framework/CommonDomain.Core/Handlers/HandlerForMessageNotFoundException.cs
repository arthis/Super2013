using System;
using System.Runtime.Serialization;

namespace CommonDomain.Core.Handlers
{
    public class HandlerForMessageNotFoundException : Exception
	{
		public HandlerForMessageNotFoundException()
		{
		}

		public HandlerForMessageNotFoundException(string message)
			: base(message)
		{
		}

		public HandlerForMessageNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public HandlerForMessageNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}