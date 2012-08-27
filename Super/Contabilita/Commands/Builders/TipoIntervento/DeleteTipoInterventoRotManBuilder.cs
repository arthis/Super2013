using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;


namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class DeleteTipoInterventoRotManBuilder : ICommandBuilder<DeleteTipoInterventoRotMan>
    {

        public DeleteTipoInterventoRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteTipoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteTipoInterventoRotMan(id,commitId,version);

            return cmd;
        }


    }
}