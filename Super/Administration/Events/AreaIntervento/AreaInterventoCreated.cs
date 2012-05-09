using System;
using CommonDomain;

namespace Super.Administration.Events.AreaIntervento
{
    public class AreaInterventoCreated : IEvent
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }

        public string ToDescription()
        {
            return string.Format("The area intervento is created (Description:'{0}',Start:'{1}',End:'{2}', Id:'{3}')", Description, Start, End, Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AreaInterventoCreated)) return false;
            return Equals((AreaInterventoCreated) obj);
        }

        public bool Equals(AreaInterventoCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(Id) && other.Start.Equals(Start) && other.End.Equals(End) && other.CreationDate.Equals(CreationDate) && Equals(other.Description, Description);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id.GetHashCode();
                result = (result*397) ^ Start.GetHashCode();
                result = (result*397) ^ (End.HasValue ? End.Value.GetHashCode() : 0);
                result = (result*397) ^ CreationDate.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
