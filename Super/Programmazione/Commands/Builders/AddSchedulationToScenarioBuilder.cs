using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public class AddSchedulationToScenarioBuilder : ICommandBuilder<AddSchedulationToScenario>
    {
        private Guid _idUser;
        private string _note;


        public AddSchedulationToScenarioBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public AddSchedulationToScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public AddSchedulationToScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddSchedulationToScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new AddSchedulationToScenario(id, idCommitId, version, _idUser, _note);

            return cmd;
        }



    }
}