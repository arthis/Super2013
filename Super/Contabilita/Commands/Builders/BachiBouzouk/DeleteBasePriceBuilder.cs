using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Pricing;

namespace Super.Contabilita.Commands.Builders.Pricing
{
    public class DeleteBasePriceBuilder : ICommandBuilder<DeleteBasePrice>
    {
        private Guid _idBasePrice;

        public DeleteBasePrice Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteBasePrice Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteBasePrice(id, commitId, version, _idBasePrice);
            return cmd;
        }

        public DeleteBasePriceBuilder ForBasePrice(Guid idBasePrice)
        {
            _idBasePrice = idBasePrice;
            return this;
        }



        
    }
}