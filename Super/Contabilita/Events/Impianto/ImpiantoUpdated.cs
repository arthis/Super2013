using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Impianto
{
    public class ImpiantoUpdated : Message
    {
        
        public Intervall Period { get; private set; }
        public string Description { get; private set; }

        public ImpiantoUpdated()
        {
            
        }

        public ImpiantoUpdated(Guid id,  Intervall period, string description)
        {
            Id = id;
            Period = period;
            Description = description;
        }
        public override string ToDescription()
        {
            return string.Format("L'impianto é stata aggiornata '{0}'.", Description);
        }

        public bool Equals(ImpiantoUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && Equals(other.Period, Period) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ImpiantoUpdated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
