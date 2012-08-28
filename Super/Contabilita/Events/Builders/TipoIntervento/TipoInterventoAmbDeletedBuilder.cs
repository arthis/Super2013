using System;
using CommonDomain;
using Super.Contabilita.Events.TipoIntervento.Ambiente;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoAmbDeletedBuilder : IEventBuilder<TipoInterventoAmbDeleted>
    {

        public TipoInterventoAmbDeleted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoAmbDeleted Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoInterventoAmbDeleted(id, commitId, version);

            return cmd;
        }


    }
}