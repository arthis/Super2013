using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.Pricing
{
    public class PricingCreated : EventBase
    {
        public PricingCreated()
        {
            
        }

        public PricingCreated(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("bachi bouzouk created " );
        }

        public bool Equals(PricingCreated other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PricingCreated);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
