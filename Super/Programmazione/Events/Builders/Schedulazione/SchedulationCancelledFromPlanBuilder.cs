using System;
using CommonDomain;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public  class SchedulazioneCancelledFromPlanBuilder : ICommandBuilder<SchedulazioneCancelledFromPlan>
    {

        public SchedulazioneCancelledFromPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneCancelledFromPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new SchedulazioneCancelledFromPlan(id, idCommitId, version);

            return cmd;
        }



    }
}