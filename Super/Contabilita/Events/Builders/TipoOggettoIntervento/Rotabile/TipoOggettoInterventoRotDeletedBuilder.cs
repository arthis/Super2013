using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Rotabile
{
    public class TipoOggettoInterventoRotDeletedBuilder : IEventBuilder<TipoOggettoInterventoRotDeleted>
    {

        public TipoOggettoInterventoRotDeleted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoOggettoInterventoRotDeleted Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoOggettoInterventoRotDeleted(id, commitId, version);

            return cmd;
        }


    }
}