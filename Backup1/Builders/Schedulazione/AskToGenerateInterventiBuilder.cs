using System;
using CommonDomain;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class AskToGenerateInterventiBuilder : ICommandBuilder<AskToGenerateInterventi>
    {


        public AskToGenerateInterventi Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AskToGenerateInterventi Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new AskToGenerateInterventi(id, idCommitId, version);

            return cmd;
        }



    }
}