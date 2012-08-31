using System;
using CommonDomain;
using Super.Contabilita.Events.bachibouzouk;

namespace Super.Contabilita.Events.Builders.bachibouzouk
{
    public class BasePriceDeletedBuilder : IEventBuilder<BasePriceDeleted>
    {

        private Guid _idBasePrice;

        public BasePriceDeleted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public BasePriceDeleted Build(Guid id, Guid commitId, long version)
        {
            var cmd = new BasePriceDeleted(id, commitId, version, _idBasePrice);
            return cmd;
        }

        public BasePriceDeletedBuilder ForBasePrice(Guid idBasePrice)
        {
            _idBasePrice = idBasePrice;
            return this;
        }




    }
}