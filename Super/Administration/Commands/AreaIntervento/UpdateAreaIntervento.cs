using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Administration.Commands.AreaIntervento
{

    public class UpdateAreaIntervento : CommandBase
    {

        public RollonPeriod Period { get; private set; }
        public string Description { get; private set; }
        public long Version { get; private set; }

        public UpdateAreaIntervento()
        {}

        public UpdateAreaIntervento(Guid id, long version, RollonPeriod period,  string description)
        {
            this.Id = id;
            this.Version = version;
            this.Period = period;
            this.Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il Area Intervento '{0}')", Description);
        }

        public bool Equals(UpdateAreaIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Period, Period) && Equals(other.Description, Description) && other.Version == Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateAreaIntervento);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ Version.GetHashCode();
                return result;
            }
        }

    }
}
