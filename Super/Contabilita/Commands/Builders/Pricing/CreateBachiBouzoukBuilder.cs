using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Commands.Builders.Pricing
{
    public class CreatePricingBuilder : ICommandBuilder<CreatePricing>
    {
        public CreatePricing Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreatePricing Build(Guid id, Guid commitId, long version)
        {
            var cmd = new CreatePricing(id, commitId, version);
            return cmd;
        }

        
    }
}