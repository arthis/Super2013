using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.bachibouzouk
{
    public class bachibouzoukCreated : Message, IEvent
    {
        public bachibouzoukCreated()
        {
            
        }

        public bachibouzoukCreated(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("bachi bouzouk created " );
        }

        public bool Equals(bachibouzoukCreated other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as bachibouzoukCreated);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
