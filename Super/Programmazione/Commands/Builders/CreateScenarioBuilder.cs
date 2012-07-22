using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public class CreateScenarioBuilder : ICommandBuilder<CreateScenario>
    {
        private Guid _idUser;
        private string _description;


        public CreateScenarioBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

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
            var cmd = new CreateScenario(id, idCommitId, version, _idUser, _description);

            return cmd;
        }



    }
}