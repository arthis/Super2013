using System;
using CommonDomain;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders.Scenario
{
    public class ScenarioCreatedBuilder : IEventBuilder<ScenarioCreated>
    {
        private Guid _idUser;
        private string _description;
        private Guid _idProgramma;


        public ScenarioCreatedBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public ScenarioCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ScenarioCreatedBuilder ForProgramma(Guid idProgramma)
        {
            _idProgramma = idProgramma;
            return this;
        }



        public ScenarioCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ScenarioCreated Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ScenarioCreated(id, idCommitId, version, _idUser, _description, _idProgramma);

            return cmd;
        }

    }
}