using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders
{
    public partial class CancelSchedulationOfPlanBuilder : ICommandBuilder<CancelSchedulationOfPlan>
    {

        public CancelSchedulationOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CancelSchedulationOfPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CancelSchedulationOfPlan(id, idCommitId, version);

            return cmd;
        }



    }
}