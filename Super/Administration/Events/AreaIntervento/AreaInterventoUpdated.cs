using System;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Administration.Events.AreaIntervento
{
    public class AreaInterventoUpdated : Message,IEvent
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        public override string ToDescription()
        {
            return string.Format("L'area intervento é stata aggiornata '{0}'.", Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (AreaInterventoUpdated)obj;

            return base.Equals(obj)
             && other.Id.Equals(Id) && other.Start.Equals(Start) && other.End.Equals(End) && Equals(other.Description, Description);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id.GetHashCode();
                result = (result*397) ^ Start.GetHashCode();
                result = (result*397) ^ (End.HasValue ? End.Value.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
