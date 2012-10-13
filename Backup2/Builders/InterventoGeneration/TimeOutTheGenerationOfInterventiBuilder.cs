using System;
using CommonDomain;
using Super.Programmazione.Commands.InterventoGeneration;

namespace Super.Programmazione.Commands.Builders.InterventoGeneration
{
    public class TimeOutTheGenerationOfInterventiBuilder : ICommandBuilder<TimeOutTheGenerationOfInterventi>
    {

        public TimeOutTheGenerationOfInterventi Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public TimeOutTheGenerationOfInterventi Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new TimeOutTheGenerationOfInterventi(id, idCommitId, version);

            return cmd;
        }

    }
}