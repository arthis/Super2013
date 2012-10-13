using System;
using CommonDomain;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders.Scenario
{
    public class ScenarioCancelledBuilder : IEventBuilder<ScenarioCancelled>
    {
        private Guid _idUser;

        public ScenarioCancelledBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        
        public ScenarioCancelled Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ScenarioCancelled Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ScenarioCancelled(id, idCommitId, version, _idUser);

            return cmd;
        }

        
    }
}