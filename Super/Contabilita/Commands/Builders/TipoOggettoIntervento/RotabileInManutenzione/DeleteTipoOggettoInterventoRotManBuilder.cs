using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.RotabileInManutenzione
{
    public class DeleteTipoOggettoInterventoRotManBuilder : ICommandBuilder<DeleteTipoOggettoInterventoRotMan>
    {

        public DeleteTipoOggettoInterventoRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteTipoOggettoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteTipoOggettoInterventoRotMan(id, commitId, version);

            return cmd;
        }


    }
}