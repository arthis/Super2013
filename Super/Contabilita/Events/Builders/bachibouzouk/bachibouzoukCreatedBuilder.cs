using System;
using CommonDomain;
using Super.Contabilita.Events.Pricing;

namespace Super.Contabilita.Events.Builders.Pricing
{
    public class PricingCreatedBuilder : IEventBuilder<PricingCreated>
    {
        public PricingCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public PricingCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new PricingCreated(id, commitId, version);
            return cmd;
        }

        
    }
}