using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Lotto
{
    public class LottoDeleted : Message
    {
        

        public LottoDeleted()
        {
            
        }

        public LottoDeleted(Guid id)
        {
            Id = id;
        }

        public override string ToDescription()
        {
            return string.Format("Il lotto é stato cancellato (Id:'{0}')", Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (LottoDeleted)obj;

            return base.Equals(obj)
             && other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
