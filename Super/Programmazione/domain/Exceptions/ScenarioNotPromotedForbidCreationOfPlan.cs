using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class ScenarioNotPromotedForbidCreationOfPlan : Exception
    {
         public ScenarioNotPromotedForbidCreationOfPlan()
		{
		}

		public ScenarioNotPromotedForbidCreationOfPlan(string message)
			: base(message)
		{
		}

		public ScenarioNotPromotedForbidCreationOfPlan(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public ScenarioNotPromotedForbidCreationOfPlan(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
   }
}