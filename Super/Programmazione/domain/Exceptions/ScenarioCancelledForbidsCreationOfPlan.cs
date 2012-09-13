using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class ScenarioCancelledForbidsCreationOfPlan : Exception
    {
        public ScenarioCancelledForbidsCreationOfPlan()
        {
        }

        public ScenarioCancelledForbidsCreationOfPlan(string message)
            : base(message)
        {
        }

        public ScenarioCancelledForbidsCreationOfPlan(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ScenarioCancelledForbidsCreationOfPlan(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}