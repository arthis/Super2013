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
        private Guid _IdScenario = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";
        private DateTime _promotingDate = DateTime.Now;
        private Guid _idProgramma = Guid.NewGuid();
        private Guid _idPlan = Guid.NewGuid();

        protected override CommandHandler<CreatePlanFromPromotedScenario> OnHandle(IEventRepository eventRepository)
        {
            return new CreatePlanFromPromotedScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .ForProgramma(_idProgramma)
                .Build(_IdScenario, 1);

            yield return BuildEvt.ScenarioPromotedToPlan
                .ByUser(_idUser)
                .WhenPromotionDate(_promotingDate)
                .ForPlan(_idPlan)
                .Build(_IdScenario, 2);
        }

        public override CreatePlanFromPromotedScenario When()
        {
            return BuildCmd.CreatePlanFromPromotedScenario
                        .FromScenario(_IdScenario)
                        .Build(_idPlan, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.PlanCreated
                .ByScenario(_IdScenario)
                .ForProgramma(_idProgramma)
                .Build(_idPlan, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
