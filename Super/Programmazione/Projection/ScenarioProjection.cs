using System;
using System.ComponentModel;
using System.Linq;
using CommonDomain.Core.Handlers;
using Super.Programmazione.Events.Scenario;
using Super.ReadModel;

namespace Super.Programmazione.Projection
{
    public class ScenarioProjection : IEventHandler<ScenarioCreated>,
                                      IEventHandler<DescriptionOfScenarioChanged>,
                                      IEventHandler<ScenarioCancelled>,
                                      IEventHandler<ScenarioPromotedToPlan>

    {

        public void Handle(ScenarioCreated @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Scenarios.SingleOrDefault(x => x.IdScenario == @event.Id);
                if (ai != null)
                    throw new Exception("Entity already created with the same id");

                ai = new Scenario()
                         {
                             IdScenario = @event.Id,
                             Description = @event.Description,
                             Version = @event.Version
                         };

                container.Scenarios.AddObject(ai);
                container.SaveChanges();
            }
        }

        public void Handle(DescriptionOfScenarioChanged @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Scenarios.SingleOrDefault(x => x.IdScenario == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.Description = @event.Description;
                ai.Version = @event.Version;

                container.SaveChanges();
            }
        }

        public void Handle(ScenarioPromotedToPlan @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Scenarios.SingleOrDefault(x => x.IdScenario == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.IsPromotedToPlan = true;
                ai.PromotingUserId = @event.IdUser;
                ai.PromotionDate = @event.PromotionDate;


                container.SaveChanges();
            }
        }

        public void Handle(ScenarioCancelled @event)
        {
            using (var container = Container.GetEntities())
            {
                var ai = container.Scenarios.SingleOrDefault(x => x.IdScenario == @event.Id);
                if (ai == null)
                    throw new Exception("Entity not found");

                ai.IsDeleted = true;
                ai.Version = @event.Version;

                container.SaveChanges();
            }
        }
    }
}
