using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public  class CancelSchedulationFromScenarioBuilder : ICommandBuilder<CancelSchedulationFromScenario>
    {

        public CancelSchedulationFromScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelSchedulationFromScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelSchedulationFromScenario(id, idCommitId, version);

            return cmd;
        }



    }
}