using System;
using CommonDomain;
using Super.Contabilita.Events.TipoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoIntervento
{
    public class TipoInterventoRotManDeletedBuilder : ICommandBuilder<TipoInterventoRotManDeleted>
    {

        public TipoInterventoRotManDeleted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoInterventoRotManDeleted Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoInterventoRotManDeleted(id,commitId,version);

            return cmd;
        }


    }
}