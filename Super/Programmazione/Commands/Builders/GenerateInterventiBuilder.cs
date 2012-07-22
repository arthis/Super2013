using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;


namespace Super.Programmazione.Commands.Builders
{
    public class GenerateInterventiBuilder : ICommandBuilder<GenerateInterventi>
    {


        public GenerateInterventi Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public GenerateInterventi Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new GenerateInterventi(id, idCommitId, version);

            return cmd;
        }



    }
}