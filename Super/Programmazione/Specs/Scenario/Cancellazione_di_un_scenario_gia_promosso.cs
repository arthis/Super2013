using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
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
    public class Cancellazione_di_un_scenario_gia_promosso : CommandBaseClass<CancelScenario>
    {
        private Guid _id = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _description = "test";
        private DateTime _promotingDate = DateTime.Now;


        protected override CommandHandler<CancelScenario> OnHandle(IEventRepository eventRepository)
        {
            var sessionFactory = new FakeSessionFactory(_idUser);
            return new CancelScenarioHandler(eventRepository, sessionFactory);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ForDescription(_description)
                .ByUser(_idUser)
                .Build(_id,1);
            yield return BuildEvt.ScenarioPromotedToPlan
                .ByUser(_idUser)
                .When(_promotingDate)
                .Build(_id, 2);
        }

        public override CancelScenario When()
        {
            return BuildCmd.CancelScenario
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

    class CancellazioneDiUnScenarioGiaPromosso : Cancellazione_di_un_scenario_gia_promosso
    {
    }
}
