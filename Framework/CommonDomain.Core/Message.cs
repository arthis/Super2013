using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CommonDomain.Core
{
    [Serializable]
    public abstract class Message : IMessage
    {
        public Guid Id { get;  set; }
        public Guid CommitId { get;  set; }
        
        

        public abstract string ToDescription();

        public Message()
        {
            
        }

        public Message(Guid id,Guid commitId)
        {
            Contract.Requires(id != Guid.Empty);
            Contract.Requires(commitId != Guid.Empty);

            Id = id;
            CommitId = commitId;
        }

        

        protected bool Equals(Message other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Message) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Id.GetHashCode();
                return hashCode;
            }
        }
    }
}
