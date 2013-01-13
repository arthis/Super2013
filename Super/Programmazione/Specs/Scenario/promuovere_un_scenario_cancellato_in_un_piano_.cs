using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class promuovere_un_scenario_cancellato_in_un_piano_ : CommandBaseClass<PromoteScenarioToPlan>
    {
        private Guid _id = Guid.NewGuid();
        
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";
        private Guid _idProgramma = Guid.NewGuid();

        private Guid _idUserPromoting = Guid.NewGuid();
        private DateTime _promotingDate = DateTime.Now;

        protected override CommandHandler<PromoteScenarioToPlan> OnHandle(IEventRepository eventRepository)
        {
            return new PromoteScenarioToPlanHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.UserAddedToSystem
                .WithFirstName("f")
                .WithLastName("l")
                .Build(_idUser, 1);
            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .ForProgramma(_idProgramma)
                .Build(_id, 1);
            yield return BuildEvt.ScenarioCancelled
             .ByUser(_idUser)
             .Build(_id, 2);

        }

        public override PromoteScenarioToPlan When()
        {
            return BuildCmd.PromoteScenarioToPlan
                        .WhenPromotionDate(_promotingDate)
                        .ForPlan(_idProgramma)
                        .Build(_id, 2, _idUser);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(ScenarioCancelledDoNotAllowFurtherChanges), Caught.GetType());
        }


    }
}
