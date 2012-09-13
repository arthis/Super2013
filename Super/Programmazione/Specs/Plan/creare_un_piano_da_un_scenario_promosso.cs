using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Plan;

namespace Super.Programmazione.Specs.Plan
{
    public class creare_un_piano_da_un_scenario_promosso : CommandBaseClass<CreatePlanFromPromotedScenario>
    {
        private Guid _Id = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";
        private DateTime _promotingDate = DateTime.Now;

        protected override CommandHandler<CreatePlanFromPromotedScenario> OnHandle(IEventRepository eventRepository)
        {
            return new CreatePlanFromPromotedScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .Build(_Id, 1);

            yield return BuildEvt.ScenarioPromotedToPlan
                .ByUser(_idUser)
                .When(_promotingDate)
                .Build(_Id, 2);
        }

        public override CreatePlanFromPromotedScenario When()
        {
            return BuildCmd.CreatePlanFromPromotedScenario
                        .FromScenario(_Id)
                        .Build(_Id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.PlanCreated
                .Build(_Id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
