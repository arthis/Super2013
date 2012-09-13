using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class ScenarioPromotedDoNotAllowChangingDescription : Exception
    {
         public ScenarioPromotedDoNotAllowChangingDescription()
		{
		}

		public ScenarioPromotedDoNotAllowChangingDescription(string message)
			: base(message)
		{
		}

		public ScenarioPromotedDoNotAllowChangingDescription(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public ScenarioPromotedDoNotAllowChangingDescription(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
   }
}