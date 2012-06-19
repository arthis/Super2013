using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;


namespace Super.Administration.Events.AreaIntervento
{
    public class AreaInterventoUpdated : Message,IEvent
    {
        public Guid Id { get; set; }
        public RollonPeriod Period { get; private set; }
        public string Description { get; private set; }
        public long Version { get; private set; }

        public AreaInterventoUpdated()
        {
            
        }

        public AreaInterventoUpdated(Guid id, long version, RollonPeriod period, string description)
        {
            Id = id;
            Version = version;
            Period = period;
            Description = description;
        }
        public override string ToDescription()
        {
            return string.Format("L'area intervento é stata aggiornata '{0}'.", Description);
        }

        public bool Equals(AreaInterventoUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && Equals(other.Period, Period) && Equals(other.Description, Description) && other.Version == Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AreaInterventoUpdated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ Version.GetHashCode();
                return result;
            }
        }
    }
}
