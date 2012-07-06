using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoControlAllowed : Message , IEvent
    {
        public InterventoControlAllowed()
        {
            
        }

        public InterventoControlAllowed(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoControlAllowed);
        }

        public override string ToDescription()
        {
            return string.Format("E permesso controllare il intervento '{0}'.", Id);
        }

        public bool Equals(InterventoControlAllowed other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ Id.GetHashCode();
            }
        }
    }
	
}
