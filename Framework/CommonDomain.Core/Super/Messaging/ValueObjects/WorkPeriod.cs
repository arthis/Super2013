using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    [Serializable]
    public class WorkPeriod
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.WorkPeriod,
        //the event representation of a value object

        public readonly DateTime StartDate;
        public readonly DateTime EndDate;

        public WorkPeriod(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        

    }
}
