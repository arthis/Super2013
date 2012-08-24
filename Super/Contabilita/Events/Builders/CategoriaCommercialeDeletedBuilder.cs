using System;
using CommonDomain;
using Super.Contabilita.Events.CategoriaCommerciale;

namespace Super.Contabilita.Events.Builders
{
    public class CategoriaCommercialeDeletedBuilder : IEventBuilder<CategoriaCommercialeDeleted>
    {

        public CategoriaCommercialeDeleted Build(Guid id, long version)
        {
            var evt = new CategoriaCommercialeDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }


}