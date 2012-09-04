using System;
using CommonDomain;
using Super.Programmazione.Events.Plan;

namespace Super.Programmazione.Events.Builders.Intervento
{
    public class InterventoCancelledFromPlanBuilder : ICommandBuilder<InterventoCancelledFromPlan>
    {

        public InterventoCancelledFromPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public InterventoCancelledFromPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new InterventoCancelledFromPlan(id, idCommitId, version);

            return cmd;
        }

    }
}