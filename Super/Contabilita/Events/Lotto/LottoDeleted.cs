using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Lotto
{
    public class LottoDeleted : EventBase
    {
        

        public LottoDeleted()
        {
            
        }

        public LottoDeleted(Guid id, Guid commitId, long version)
            :base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Il lotto é stato cancellato (Id:'{0}')", Id);
        }

        public bool Equals(LottoDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as LottoDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
