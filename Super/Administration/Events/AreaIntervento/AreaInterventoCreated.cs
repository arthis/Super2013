using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;


namespace Super.Administration.Events.AreaIntervento
{
    public class AreaInterventoCreated :  Message ,IEvent
    {
        public Guid Id { get; set; }
        public Intervall Period { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Description { get; private set; }
        public long Version { get; private set; }

        public AreaInterventoCreated(Guid id, long version, Intervall period, DateTime creationDate, string description)
        {
            Id = id;
            Version = version;
            Period = period;
            CreationDate = creationDate;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("L'area intervento é stata creata '{0}'.", Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AreaInterventoCreated);
        }

        public bool Equals(AreaInterventoCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && Equals(other.Period, Period) && other.CreationDate.Equals(CreationDate) && Equals(other.Description, Description) && other.Version == Version;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ CreationDate.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ Version.GetHashCode();
                return result;
            }
        }
    }
}
