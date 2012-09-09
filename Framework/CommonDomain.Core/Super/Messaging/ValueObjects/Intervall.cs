using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.Builders;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    [Serializable]
    public class Interval
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.Interval,
        //the event representation of a value object

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public Interval()
        {}

        public Interval(DateTime startDate, DateTime? endDate)
        {
            Contract.Requires(startDate > DateTime.MinValue);

            Start = startDate;
            End = endDate;
        }

        public bool Equals(Interval other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Start.Equals(Start) && other.End.Equals(End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Interval)) return false;
            return Equals((Interval) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Start.GetHashCode()*397) ^ (End.HasValue ? End.Value.GetHashCode() : 0);
            }
        }
    }
}
