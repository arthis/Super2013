using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders
{
    public  class CancelSchedulationFromPlanBuilder : ICommandBuilder<CancelSchedulationFromPlan>
    {

        public CancelSchedulationFromPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelSchedulationFromPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelSchedulationFromPlan(id, idCommitId, version);

            return cmd;
        }



    }
}