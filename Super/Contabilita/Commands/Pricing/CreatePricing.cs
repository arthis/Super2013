using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Pricing
{
    public class CreatePricing : CommandBase
    {
        public CreatePricing()
        {
            
        }

        public CreatePricing(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("create bachi bouzouk  " );
        }

        public bool Equals(CreatePricing other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreatePricing);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
