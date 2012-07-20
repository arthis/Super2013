using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.Committente
{

    public class UpdateCommittente : CommandBase
    {

        public string Description { get; set; }
        public string Sign { get; set; }

        public UpdateCommittente()
        {}

        public UpdateCommittente(Guid id, Guid commitId, long version, string description, string sign)
            :base (id,commitId,version)
        {
            
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(sign));

            Sign = sign;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il committente '{0}')", Description);
        }

        public bool Equals(UpdateCommittente other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && Equals(other.Sign, Sign);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateCommittente);
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
