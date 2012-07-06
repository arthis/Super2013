using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Impianto
{
    public class ImpiantoDeleted : Message, IEvent
    {
        

        public ImpiantoDeleted()
        {
            
        }

        public ImpiantoDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("L'impianto é stata cancellata (Id:'{0}')", Id);
        }

        public bool Equals(ImpiantoDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ImpiantoDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
