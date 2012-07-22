using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Builders
{
    public class PromoteScenarioToPlanBuilder : ICommandBuilder<PromoteScenarioToPlan>
    {
        private Guid _idUser;
        private DateTime _promotionDate;


        public PromoteScenarioToPlanBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

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
            var cmd = new PromoteScenarioToPlan(id, idCommitId, version, _idUser,_promotionDate);

            return cmd;
        }



    }
}