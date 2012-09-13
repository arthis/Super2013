using System;
using CommonDomain;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders.Scenario
{
    public class ScenarioCreatedBuilder : IEventBuilder<ScenarioCreated>
    {
        private Guid _idUser;
        private string _description;


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

        public ScenarioCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ScenarioCreated Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ScenarioCreated(id, idCommitId, version, _idUser, _description);

            return cmd;
        }

    }
}