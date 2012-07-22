using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Intervento
{
    public  class DeleteIntervento : CommandBase
    {
        
        public DeleteIntervento()
        {
            
        }

        public DeleteIntervento(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Cancellare un scenario {0}", Id);
        }

        public bool Equals(DeleteIntervento other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DeleteIntervento);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}