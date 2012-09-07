using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class SchedulazionealreadyGeneratedException : Exception
    {
         public SchedulazionealreadyGeneratedException()
		{
		}

		public SchedulazionealreadyGeneratedException(string message)
			: base(message)
		{
		}

		public SchedulazionealreadyGeneratedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public SchedulazionealreadyGeneratedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
    }
}