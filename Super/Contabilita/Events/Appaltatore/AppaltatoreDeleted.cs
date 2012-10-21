using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Appaltatore
{
    public class AppaltatoreDeleted : EventBase
    {
        

        public AppaltatoreDeleted()
        {
            
        }

        public AppaltatoreDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("L'appaltatore é stata cancellata (Id:'{0}')", Id);
        }

        public bool Equals(AppaltatoreDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AppaltatoreDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
