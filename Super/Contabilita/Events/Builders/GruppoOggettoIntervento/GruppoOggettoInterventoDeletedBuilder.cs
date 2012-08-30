using System;
using CommonDomain;
using Super.Contabilita.Events.GruppoOggettoIntervento;

namespace Super.Contabilita.Events.Builders.GruppoOggettoIntervento
{
    public class GruppoOggettoInterventoDeletedBuilder : IEventBuilder<GruppoOggettoInterventoDeleted>
    {

        public GruppoOggettoInterventoDeleted Build(Guid id, long version)
        {
            var evt = new GruppoOggettoInterventoDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }


}