using System;
using CommonDomain;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class CreatePlanBuilder : ICommandBuilder<CreatePlan>
    {

        public CreatePlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreatePlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CreatePlan(id, idCommitId, version);

            return cmd;
        }

    }
}