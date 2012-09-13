using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public class ChangeDescriptionScenarioBuilder : ICommandBuilder<ChangeDescriptionScenario>
    {
        private string _description;

        public ChangeDescriptionScenarioBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ChangeDescriptionScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ChangeDescriptionScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ChangeDescriptionScenario(id, idCommitId, version, _description);

            return cmd;
        }



    }
}