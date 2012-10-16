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
        public DateTime? WakeTime { get; set; }

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

        public Message(Guid id, Guid commitId, long version,DateTime wakeTime)
        {
            Contract.Requires(id != Guid.Empty);
            Contract.Requires(commitId != Guid.Empty);
            Contract.Requires(version >= 0);
            Contract.Requires(wakeTime> DateTime.MinValue);

            Id = id;
            CommitId = commitId;
            Version = version;
            WakeTime = wakeTime;
        }

        protected bool Equals(Message other)
        {
            return Id.Equals(other.Id) && Version == other.Version && WakeTime.Equals(other.WakeTime);
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
                hashCode = (hashCode*397) ^ Version.GetHashCode();
                hashCode = (hashCode*397) ^ WakeTime.GetHashCode();
                return hashCode;
            }
        }
    }
}
