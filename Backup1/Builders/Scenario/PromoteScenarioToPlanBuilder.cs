using System;
using CommonDomain;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public class PromoteScenarioToPlanBuilder : ICommandBuilder<PromoteScenarioToPlan>
    {
        private DateTime _promotionDate;



        public PromoteScenarioToPlanBuilder When(DateTime promotionDate)
        {
            _promotionDate = promotionDate;
            return this;
        }

        public PromoteScenarioToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public PromoteScenarioToPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new PromoteScenarioToPlan(id, idCommitId, version, _promotionDate);

            return cmd;
        }



    }
}