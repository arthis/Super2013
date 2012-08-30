using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class TipoOggettoInterventoRotManCreatedBuilder : IEventBuilder<TipoOgettoInterventoRotManCreated>
    {

        public TipoOgettoInterventoRotManCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoOgettoInterventoRotManCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoOgettoInterventoRotManCreated(id, commitId, version);

            return cmd;
        }


    }
}