using System;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Administration.Events.AreaIntervento
{
    public class AreaInterventoDeleted : Message,IEvent
    {
        public Guid Id { get; set; }


        public override string ToDescription()
        {
            return string.Format("The area intervento is deleted (Id:'{0}')", Id);
        }

        

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(AreaInterventoDeleted other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
