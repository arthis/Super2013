using System;
using CommonDomain;
using Super.Contabilita.Events.Impianto;

namespace Super.Contabilita.Events.Builders
{
    public class ImpiantoDeletedBuilder : IEventBuilder<ImpiantoDeleted>
    {

        public ImpiantoDeleted Build(Guid id)
        {
            return new ImpiantoDeleted(id);
        }

    }
}