using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Rotabile
{
    public class DeleteTipoOggettoInterventoRotBuilder : ICommandBuilder<DeleteTipoOggettoInterventoRot>
    {

        public DeleteTipoOggettoInterventoRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteTipoOggettoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteTipoOggettoInterventoRot(id, commitId, version);

            return cmd;
        }


    }
}