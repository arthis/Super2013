using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public class UpdateScenarioBuilder : ICommandBuilder<UpdateScenario>
    {
        private string _description;

        public UpdateScenarioBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new UpdateScenario(id, idCommitId, version, _description);

            return cmd;
        }



    }
}