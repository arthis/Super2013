using System;
using CommonDomain;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders.Scenario
{
    public class DescriptionOfScenarioChangedBuilder : IEventBuilder<DescriptionOfScenarioChanged>
    {
        private string _description;

        public DescriptionOfScenarioChangedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public DescriptionOfScenarioChanged Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DescriptionOfScenarioChanged Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new DescriptionOfScenarioChanged(id, idCommitId, version, _description);

            return cmd;
        }



    }
}