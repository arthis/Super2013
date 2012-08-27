using System;
using CommonDomain;
using Super.Contabilita.Events.CategoriaCommerciale;

namespace Super.Contabilita.Events.Builders.CategoriaCommerciale
{
    public class CategoriaCommercialeCreatedBuilder : IEventBuilder<CategoriaCommercialeCreated>
    {
        private string _description;


        public CategoriaCommercialeCreated Build(Guid id, long version)
        {
            var evt = new CategoriaCommercialeCreated(id, Guid.NewGuid() ,version,    _description);
            
            return evt;
        }


        public CategoriaCommercialeCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }

}