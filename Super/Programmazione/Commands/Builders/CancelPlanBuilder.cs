using System;
using CommonDomain;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public class CancelPlanBuilder : ICommandBuilder<CancelPlan>
    {

        public CancelPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelPlan(id, idCommitId, version);

            return cmd;
        }

    }
}