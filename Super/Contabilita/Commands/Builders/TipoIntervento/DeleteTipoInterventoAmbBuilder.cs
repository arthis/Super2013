using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;

namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class DeleteTipoInterventoAmbBuilder : ICommandBuilder<DeleteTipoInterventoAmb>
    {

        public DeleteTipoInterventoAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteTipoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteTipoInterventoAmb(id,commitId,version);

            return cmd;
        }


    }
}