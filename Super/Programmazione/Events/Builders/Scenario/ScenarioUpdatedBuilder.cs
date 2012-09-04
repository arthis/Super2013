using System;
using CommonDomain;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders.Scenario
{
    public class ScenarioUpdatedBuilder : ICommandBuilder<ScenarioUpdated>
    {
        private string _description;

        public ScenarioUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ScenarioUpdated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ScenarioUpdated Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ScenarioUpdated(id, idCommitId, version, _description);

            return cmd;
        }



    }
}