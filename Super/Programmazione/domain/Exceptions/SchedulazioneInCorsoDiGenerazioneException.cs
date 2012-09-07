using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class SchedulazioneInCorsoDiGenerazioneException : Exception
    {
         public SchedulazioneInCorsoDiGenerazioneException()
		{
		}

		public SchedulazioneInCorsoDiGenerazioneException(string message)
			: base(message)
		{
		}

		public SchedulazioneInCorsoDiGenerazioneException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public SchedulazioneInCorsoDiGenerazioneException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
    }
}