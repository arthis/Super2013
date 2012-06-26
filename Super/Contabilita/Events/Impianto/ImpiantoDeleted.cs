using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Impianto
{
    public class ImpiantoDeleted : Message,IEvent
    {
        public Guid Id { get; set; }

        public ImpiantoDeleted()
        {
            
        }

        public ImpiantoDeleted(Guid id)
        {
            Id = id;
        }

        public override string ToDescription()
        {
            return string.Format("L'impianto é stata cancellata (Id:'{0}')", Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (ImpiantoDeleted)obj;

            return base.Equals(obj)
             && other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
