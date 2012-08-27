using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Committente
{
    public class CommittenteUpdated : Message, IEvent
    {
        
        public string Description { get; set; }
        public string Sign { get; set; }

        public CommittenteUpdated()
        {
            
        }

        public CommittenteUpdated(Guid id, Guid commitId, long version,  string description, string sign)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(!string.IsNullOrEmpty(sign));
            
            Description = description;
            Sign = sign;
        }

        public override string ToDescription()
        {
            return string.Format("Il committente é stato aggiornato '{0}'.", Description);
        }

        public bool Equals(CommittenteUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && Equals(other.Sign, Sign);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CommittenteUpdated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Sign != null ? Sign.GetHashCode() : 0);
                return result;
            }
        }
    }
}
