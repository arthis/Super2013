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
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }


        //for serialization
        public LottoCreated()
        {
            
        }

        public LottoCreated(Guid id, Guid commitId, long version, Interval period,  DateTime creationDate, string description)
            : base(id, commitId, version)
        
        {
            Contract.Requires(period != null);
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(creationDate > DateTime.MinValue);

            Interval = period;
            CreationDate = creationDate;
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
            return base.Equals(other) && other.Id.Equals(Id) && Equals(other.Interval, Interval) && other.CreationDate.Equals(CreationDate) && Equals(other.Description, Description);
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
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
                result = (result*397) ^ CreationDate.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
