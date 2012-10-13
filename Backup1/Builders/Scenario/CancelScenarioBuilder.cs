using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public class CancelScenarioBuilder : ICommandBuilder<CancelScenario>
    {
        
        public CancelScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelScenario(id, idCommitId, version);

            return cmd;
        }

    }
}