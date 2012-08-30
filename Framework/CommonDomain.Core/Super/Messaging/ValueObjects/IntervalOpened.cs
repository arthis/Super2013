using System;
using System.Diagnostics.Contracts;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    [Serializable]
    public class IntervalOpened
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.Interval,
        //the event representation of a value object

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public IntervalOpened()
        { }

        public IntervalOpened(DateTime? startDate, DateTime? endDate)
        {
            if(startDate.HasValue&& endDate.HasValue)
                Contract.Requires( startDate<= endDate);

            Start = startDate;
            End = endDate;
        }

        public bool Equals(IntervalOpened other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Start.Equals(Start) && other.End.Equals(End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (IntervalOpened)) return false;
            return Equals((IntervalOpened) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Start.HasValue ? Start.Value.GetHashCode() : 0)*397) ^ (End.HasValue ? End.Value.GetHashCode() : 0);
            }
        }
    }
}