using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Administration.Commands.AreaIntervento
{
    
    public class CreateAreaIntervento : CommandBase
    {
        public RollonPeriod Period { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long Version { get; private set; }

        public CreateAreaIntervento()
        {
            
        }

        public CreateAreaIntervento(Guid id, long version, RollonPeriod period, DateTime creationDate, string description)
        {
            this.Id = id;
            this.Version = version;
            this.Period = period;
            this.Description = description;
            this.CreationDate = creationDate;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il area Intervento '{0}'.", Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateAreaIntervento);
        }

        public bool Equals(CreateAreaIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Period, Period) && Equals(other.Description, Description) && other.CreationDate.Equals(CreationDate) && other.Version == Version;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ CreationDate.GetHashCode();
                result = (result*397) ^ Version.GetHashCode();
                return result;
            }
        }
    }
}
