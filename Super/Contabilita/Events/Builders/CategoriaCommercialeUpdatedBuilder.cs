using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.CategoriaCommerciale;

namespace Super.Contabilita.Events.Builders
{
    public class CategoriaCommercialeUpdatedBuilder : IEventBuilder<CategoriaCommercialeUpdated>
    {
        private string _description;

        public CategoriaCommercialeUpdated Build(Guid id, long version)
        {
            var evt = new CategoriaCommercialeUpdated(id, Guid.NewGuid() ,version,  _description);
            
            return evt;
        }

        public CategoriaCommercialeUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }


}