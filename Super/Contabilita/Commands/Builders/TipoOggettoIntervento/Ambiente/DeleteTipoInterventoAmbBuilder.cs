using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Ambiente
{
    public class DeleteTipoOggettoInterventoAmbBuilder : ICommandBuilder<DeleteTipoOggettoInterventoAmb>
    {

        public DeleteTipoOggettoInterventoAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteTipoOggettoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteTipoOggettoInterventoAmb(id, commitId, version);

            return cmd;
        }


    }
}