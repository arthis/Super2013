using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public class CreateScenarioBuilder : ICommandBuilder<CreateScenario>
    {

        private string _description;
        private Guid _idProgramma;


        public CreateScenarioBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateScenarioBuilder WithProgramma(Guid idProgramma)
        {
            _idProgramma = idProgramma;
            return this;
        }


        public CreateScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CreateScenario(id, idCommitId, version, _description, _idProgramma);

            return cmd;
        }



    }
}