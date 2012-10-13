using System;
using CommonDomain;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class CreatePlanFromPromotedScenarioBuilder : ICommandBuilder<CreatePlanFromPromotedScenario>
    {
        private Guid _idScenario;

        public CreatePlanFromPromotedScenarioBuilder FromScenario (Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public CreatePlanFromPromotedScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreatePlanFromPromotedScenario Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new CreatePlanFromPromotedScenario(id, idCommitId, version, _idScenario);

            return cmd;
        }

    }
}