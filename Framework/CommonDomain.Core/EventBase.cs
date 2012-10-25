using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;

namespace CommonDomain.Core
{
    public abstract class EventBase : Message, IEvent
    {
        public long Version { get;  set; }
        

        public EventBase()
        {
            
        }

        public EventBase(Guid id, Guid commitId, long version)
            :base(id,commitId)
        {
            Contract.Requires(version >= (long)(0));

            Version = version;
        }

        protected bool Equals(EventBase other)
        {
            return base.Equals(other) && Version == other.Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EventBase) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ Version.GetHashCode();
            }
        }
    }
}
