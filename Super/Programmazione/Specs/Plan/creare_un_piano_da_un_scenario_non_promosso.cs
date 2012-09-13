using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Plan;

namespace Super.Programmazione.Specs.Plan
{
    public class creare_un_piano_da_un_scenario_non_promosso : CommandBaseClass<CreatePlanFromPromotedScenario>
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
   
        }

        public override CreatePlanFromPromotedScenario When()
        {
            return BuildCmd.CreatePlanFromPromotedScenario
                        .FromScenario(_Id)
                        .Build(_Id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(ScenarioNotPromotedForbidCreationOfPlan), Caught.GetType());
        }


    }
}
