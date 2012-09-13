using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
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
    public class promuovere_un_scenario_promosso_in_un_piano : CommandBaseClass<PromoteScenarioToPlan>
    {
        private Guid _id = Guid.NewGuid();
        
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";

        private Guid _idUserPromoting = Guid.NewGuid();
        private DateTime _promotingDate = DateTime.Now;

        protected override CommandHandler<PromoteScenarioToPlan> OnHandle(IEventRepository eventRepository)
        {
            var sessionFactory = new FakeSessionFactory(_idUser);
            return new PromoteScenarioToPlanHandler(eventRepository, sessionFactory);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .Build(_id, 1);
            yield return BuildEvt.ScenarioPromotedToPlan
              .ByUser(_idUserPromoting)
              .When(_promotingDate)
              .Build(_id, 2);
        }

        public override PromoteScenarioToPlan When()
        {
            return BuildCmd.PromoteScenarioToPlan
                        .When(_promotingDate)
                        .Build(_id, 2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(ScenarioPromotedDoNotAllowChangingDescription), Caught.GetType());
        }


    }
}
