using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.Builders;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    [Serializable]
    public class Intervall
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.Intervall,
        //the event representation of a value object

        public readonly DateTime Start;
        public readonly DateTime? End;

        public Intervall(DateTime startDate, DateTime? endDate)
        {
            Start = startDate;
            End = endDate;
        }

    }
}
