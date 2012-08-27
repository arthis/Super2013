using System;
using CommonDomain;
using Super.Contabilita.Events.Impianto;

namespace Super.Contabilita.Events.Builders.Impianto
{
    public class ImpiantoDeletedBuilder : IEventBuilder<ImpiantoDeleted>
    {

        public ImpiantoDeleted Build(Guid id, long version)
        {
            var evt = new ImpiantoDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }
}