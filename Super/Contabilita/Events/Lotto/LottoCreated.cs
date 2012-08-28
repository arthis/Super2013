using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Lotto
{
    public class LottoCreated : Message, IEvent
    {
        public Interval Interval { get; set; }
        public string Description { get; set; }


        //for serialization
        public LottoCreated()
        {
            
        }

        public LottoCreated(Guid id, Guid commitId, long version, Interval period,   string description)
            : base(id, commitId, version)
        
        {
            Contract.Requires(period != null);
            Contract.Requires(!string.IsNullOrEmpty(description));

            Interval = period;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Il lotto é stato creato '{0}'.", Description);
        }

        public bool Equals(LottoCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Interval, Interval) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as LottoCreated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
