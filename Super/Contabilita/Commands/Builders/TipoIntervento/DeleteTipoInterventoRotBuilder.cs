using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;


namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class DeleteTipoInterventoRotBuilder : ICommandBuilder<DeleteTipoInterventoRot>
    {

        public DeleteTipoInterventoRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteTipoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteTipoInterventoRot(id,commitId,version);

            return cmd;
        }


    }
}