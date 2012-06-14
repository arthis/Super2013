using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoClosed : Message, IEvent
    {
        public Guid Id { get; set; }
        public Guid IdUtente { get; set; }
        public DateTime ClosingDate { get; set; }

       
        public override string ToDescription()
        {
            return string.Format("Il intervento '{0}' é stato chiuso.", Id);
        }

        public bool Equals(InterventoClosed other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && other.IdUtente.Equals(IdUtente) && other.ClosingDate.Equals(ClosingDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoClosed);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ IdUtente.GetHashCode();
                result = (result*397) ^ ClosingDate.GetHashCode();
                return result;
            }
        }
    }
	
}
