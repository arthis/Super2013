using System;
using CommonDomain;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public  class SchedulazioneCancelledFromScenarioBuilder : ICommandBuilder<SchedulazioneCancelledFromScenario>
    {

        public SchedulazioneCancelledFromScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneCancelledFromScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new SchedulazioneCancelledFromScenario(id, idCommitId, version);

            return cmd;
        }



    }
}