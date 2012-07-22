using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public class UpdateSchedulationOfScenarioBuilder : ICommandBuilder<UpdateSchedulationOfScenario>
    {
        private string _note;

        public UpdateSchedulationOfScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public UpdateSchedulationOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateSchedulationOfScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new UpdateSchedulationOfScenario(id, idCommitId, version, _note);

            return cmd;
        }



    }
}