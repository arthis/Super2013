using System;
using CommonDomain;
using Super.Administration.Events.AreaIntervento;

namespace Super.Administration.Events.Builders
{
    public class AreaInterventoDeletedBuilder : IEventBuilder<AreaInterventoDeleted>
    {

        public AreaInterventoDeleted Build(Guid id, long version)
        {
            return new AreaInterventoDeleted(id, version);
        }

    }
}