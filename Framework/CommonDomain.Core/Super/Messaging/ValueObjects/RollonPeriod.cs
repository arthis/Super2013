using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.Builders;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    public class RollonPeriod
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.RollonPeriod,
        //the event representation of a value object

        public readonly DateTime Start;
        public readonly DateTime? End;

        public RollonPeriod(DateTime startDate, DateTime? endDate)
        {
            Start = startDate;
            End = endDate;
        }

    }
}
