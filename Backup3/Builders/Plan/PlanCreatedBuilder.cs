using System;
using CommonDomain;
using Super.Programmazione.Events.Plan;

namespace Super.Programmazione.Events.Builders.Plan
{
    public class PlanCreatedBuilder : IEventBuilder<PlanCreated>
    {

        public PlanCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public PlanCreated Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new PlanCreated(id, idCommitId, version);

            return cmd;
        }

    }
}