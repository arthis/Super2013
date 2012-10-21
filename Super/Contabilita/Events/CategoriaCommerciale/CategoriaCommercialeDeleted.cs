using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.CategoriaCommerciale
{
    public class CategoriaCommercialeDeleted : EventBase
    {
        

        public CategoriaCommercialeDeleted()
        {
            
        }

        public CategoriaCommercialeDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("La categoria commerciale é stata cancellata (Id:'{0}')", Id);
        }

        public bool Equals(CategoriaCommercialeDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CategoriaCommercialeDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
