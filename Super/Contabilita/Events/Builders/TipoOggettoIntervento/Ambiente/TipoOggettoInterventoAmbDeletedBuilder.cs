using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.Ambiente
{
    public class TipoOggettoInterventoAmbDeletedBuilder : IEventBuilder<TipoOggettoInterventoAmbDeleted>
    {

        public TipoOggettoInterventoAmbDeleted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoOggettoInterventoAmbDeleted Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoOggettoInterventoAmbDeleted(id, commitId, version);

            return cmd;
        }


    }
}