using System;
using CommonDomain;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class CancelInterventoFromPlanBuilder : ICommandBuilder<CancelInterventoFromPlan>
    {

        public CancelInterventoFromPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelInterventoFromPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelInterventoFromPlan(id, idCommitId, version);

            return cmd;
        }

    }
}