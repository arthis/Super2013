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
        public Guid Id { get; set; }
        public Guid CommitId { get; set; }
        public long Version { get; set; }

        public abstract string ToDescription();

        public Message()
        {
            
        }

        public Message(Guid id,Guid commitId, long version)
        {
            Contract.Requires(id != Guid.Empty);
            Contract.Requires(commitId != Guid.Empty);
            Contract.Requires(version>=0);

            Id = id;
            CommitId = commitId;
            Version = version;
        }

        public bool Equals(Message other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(Id) && other.Version == Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Message)) return false;
            return Equals((Message) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id.GetHashCode();
                result = (result*397) ^ CommitId.GetHashCode();
                result = (result*397) ^ Version.GetHashCode();
                return result;
            }
        }
    }
}
