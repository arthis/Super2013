using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Committente
{
    public class CommittenteDeleted : EventBase
    {
        

        public CommittenteDeleted()
        {
            
        }

        public CommittenteDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Il committente é stato cancellato (Id:'{0}')", Id);
        }

        public bool Equals(CommittenteDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CommittenteDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
