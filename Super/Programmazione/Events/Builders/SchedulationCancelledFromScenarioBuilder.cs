using System;
using CommonDomain;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders
{
    public  class SchedulationCancelledFromScenarioBuilder : ICommandBuilder<SchedulationCancelledFromScenario>
    {

        public SchedulationCancelledFromScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulationCancelledFromScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new SchedulationCancelledFromScenario(id, idCommitId, version);

            return cmd;
        }



    }
}