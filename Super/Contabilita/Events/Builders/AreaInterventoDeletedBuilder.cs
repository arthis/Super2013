using System;
using CommonDomain;
using Super.Contabilita.Events.AreaIntervento;

namespace Super.Contabilita.Events.Builders
{
    public class AreaInterventoDeletedBuilder : IEventBuilder<AreaInterventoDeleted>
    {

        public AreaInterventoDeleted Build(Guid id, long version)
        {
            return new AreaInterventoDeleted(id, version);
        }

    }
}