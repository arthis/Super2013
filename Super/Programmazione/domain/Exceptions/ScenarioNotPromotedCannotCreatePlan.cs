using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class ScenarioNotPromotedCannotCreatePlan : Exception
    {
        public ScenarioNotPromotedCannotCreatePlan()
        {
        }

        public ScenarioNotPromotedCannotCreatePlan(string message)
            : base(message)
        {
        }

        public ScenarioNotPromotedCannotCreatePlan(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ScenarioNotPromotedCannotCreatePlan(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}