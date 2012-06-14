using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoReopened : Message, IEvent
    {
        public Guid Id { get; set; }
        public Guid IdUtente { get; set; }
        public DateTime ReopeningDate { get; set; }

       
        public override string ToDescription()
        {
            return string.Format("Il intervento '{0}' é stato aperto di nuovo.", Id);
        }

        public bool Equals(InterventoReopened other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && other.IdUtente.Equals(IdUtente) && other.ReopeningDate.Equals(ReopeningDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoReopened);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ IdUtente.GetHashCode();
                result = (result * 397) ^ ReopeningDate.GetHashCode();
                return result;
            }
        }
    }
	
}
