using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class ScenarioPromotedDoNotAllowFurtherChanges : Exception
    {
         public ScenarioPromotedDoNotAllowFurtherChanges()
		{
		}

		public ScenarioPromotedDoNotAllowFurtherChanges(string message)
			: base(message)
		{
		}

		public ScenarioPromotedDoNotAllowFurtherChanges(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public ScenarioPromotedDoNotAllowFurtherChanges(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
   }
}