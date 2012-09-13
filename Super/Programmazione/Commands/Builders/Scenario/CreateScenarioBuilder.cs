using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public class CreateScenarioBuilder : ICommandBuilder<CreateScenario>
    {

        private string _description;


        public CreateScenarioBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CreateScenario(id, idCommitId, version,  _description);

            return cmd;
        }



    }
}