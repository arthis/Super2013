using System;
using CommonDomain;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Events.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class TipoOggettoInterventoRotManDeletedBuilder : ICommandBuilder<TipoOggettoInterventoRotManDeleted>
    {

        public TipoOggettoInterventoRotManDeleted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TipoOggettoInterventoRotManDeleted Build(Guid id, Guid commitId, long version)
        {
            var cmd = new TipoOggettoInterventoRotManDeleted(id, commitId, version);

            return cmd;
        }


    }
}