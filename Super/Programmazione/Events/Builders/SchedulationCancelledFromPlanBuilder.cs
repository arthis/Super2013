using System;
using CommonDomain;
using Super.Programmazione.Events.Plan;

namespace Super.Programmazione.Events.Builders
{
    public  class SchedulationCancelledFromPlanBuilder : ICommandBuilder<SchedulationCancelledFromPlan>
    {

        public SchedulationCancelledFromPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulationCancelledFromPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new SchedulationCancelledFromPlan(id, idCommitId, version);

            return cmd;
        }



    }
}