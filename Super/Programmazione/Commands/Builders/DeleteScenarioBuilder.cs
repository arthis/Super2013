using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public class DeleteScenarioBuilder : ICommandBuilder<DeleteScenario>
    {
        
        public DeleteScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new DeleteScenario(id, idCommitId, version);

            return cmd;
        }

    }
}