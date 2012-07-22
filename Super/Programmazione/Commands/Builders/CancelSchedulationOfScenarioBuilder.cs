using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public partial class CancelSchedulationOfScenarioBuilder : ICommandBuilder<CancelSchedulationOfScenario>
    {

        public CancelSchedulationOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelSchedulationOfScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelSchedulationOfScenario(id, idCommitId, version);

            return cmd;
        }



    }
}