using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.PeriodoProgrammazione
{
    public class PeriodoProgrammazioneCreated : Message, IEvent
    {
        public Interval Interval { get; set; }
        public string Description { get;  set; }

        //for serialization
        public PeriodoProgrammazioneCreated()
        {
            
        }

        public PeriodoProgrammazioneCreated(Guid id, Guid commitId, long version, Interval interval, string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(interval!=null);

            Description = description;
            Interval = interval;
        }

        public override string ToDescription()
        {
            return string.Format("Il periodo programazione é stato creato '{0}'.", Description);
        }

        public bool Equals(PeriodoProgrammazioneCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Interval, Interval) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PeriodoProgrammazioneCreated);
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
