using System;
using CommonDomain;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders.Plan
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