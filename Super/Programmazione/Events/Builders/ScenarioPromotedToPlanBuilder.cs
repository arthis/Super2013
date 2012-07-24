using System;
using CommonDomain;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders
{
    public class ScenarioPromotedToPlanBuilder : ICommandBuilder<ScenarioPromotedToPlan>
    {
        private Guid _idUser;
        private DateTime _promotionDate;


        public ScenarioPromotedToPlanBuilder ByUser(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public ScenarioPromotedToPlanBuilder When(DateTime promotionDate)
        {
            _promotionDate = promotionDate;
            return this;
        }

        public ScenarioPromotedToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ScenarioPromotedToPlan Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new ScenarioPromotedToPlan(id, idCommitId, version, _idUser,_promotionDate);

            return cmd;
        }



    }
}