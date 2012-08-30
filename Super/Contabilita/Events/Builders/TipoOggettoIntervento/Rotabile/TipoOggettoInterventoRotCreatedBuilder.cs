using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Rotabile
{
    public class TipoOggettoInterventoRotCreatedBuilder : IEventBuilder<TipoOgettoInterventoRotCreated>
    {

        public TipoOgettoInterventoRotCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoOgettoInterventoRotCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoOgettoInterventoRotCreated(id, commitId, version);

            return cmd;
        }


    }
}