using System;
using CommonDomain;
using Super.Contabilita.Commands.PeriodoProgrammazione;

namespace Super.Contabilita.Commands.Builders.PeriodoProgrammazione
{
    public class DeletePeriodoProgrammazioneBuilder : ICommandBuilder<DeletePeriodoProgrammazione>
    {

        public DeletePeriodoProgrammazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeletePeriodoProgrammazione Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeletePeriodoProgrammazione(id,commitId,version);

            return cmd;
        }


    }
}