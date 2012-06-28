using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    [Serializable]
    public class WorkPeriod
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.WorkPeriod,
        //the event representation of a value object

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public WorkPeriod(DateTime startDate, DateTime endDate)
        {
            Contract.Requires<ArgumentNullException>(startDate > DateTime.MinValue);
            Contract.Requires<ArgumentNullException>(endDate > DateTime.MinValue);

            StartDate = startDate;
            EndDate = endDate;
        }

        public bool Equals(WorkPeriod other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.StartDate.Equals(StartDate) && other.EndDate.Equals(EndDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (WorkPeriod)) return false;
            return Equals((WorkPeriod) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (StartDate.GetHashCode()*397) ^ EndDate.GetHashCode();
            }
        }
    }
}
