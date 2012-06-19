using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    public class RolloutPeriod
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.RolloutPeriod,
        //the event representation of a value object

        public readonly DateTime StartDate;
        public readonly DateTime EndDate;

        public RolloutPeriod(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
