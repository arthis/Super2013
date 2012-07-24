using System;
using CommonDomain;
using Super.Programmazione.Events.Plan;

namespace Super.Programmazione.Events.Builders
{
    public class PlanCancelledBuilder : ICommandBuilder<PlanCancelled>
    {

        public PlanCancelled Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public PlanCancelled Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new PlanCancelled(id, idCommitId, version);

            return cmd;
        }

    }
}