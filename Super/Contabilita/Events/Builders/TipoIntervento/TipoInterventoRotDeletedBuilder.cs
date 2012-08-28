using System;
using CommonDomain;
using Super.Contabilita.Events.TipoIntervento.Rotabile;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoRotDeletedBuilder : IEventBuilder<TipoInterventoRotDeleted>
    {

        public TipoInterventoRotDeleted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoRotDeleted Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoInterventoRotDeleted(id,commitId,version);

            return cmd;
        }


    }
}