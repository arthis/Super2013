using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public abstract class Message : IMessage
    {
        public Guid CommitId { get; set; }

        public abstract string ToDescription();


        public Message()
        {
            
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Message);
        }

        public bool Equals(Message other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.CommitId.Equals(CommitId);
        }

        public override int GetHashCode()
        {
            return CommitId.GetHashCode();
        }
    }
}
