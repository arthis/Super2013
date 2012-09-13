using System;
using CommonDomain;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders.Scenario
{
    public class ScenarioDeletedBuilder : IEventBuilder<ScenarioDeleted>
    {
        
        public ScenarioDeleted Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ScenarioDeleted Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ScenarioDeleted(id, idCommitId, version);

            return cmd;
        }

    }
}