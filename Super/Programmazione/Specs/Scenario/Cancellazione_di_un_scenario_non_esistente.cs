using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class Cancellazione_di_un_scenario_non_esistente : CommandBaseClass<CancelScenario>
    {
        private Guid _id = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();

        protected override CommandHandler<CancelScenario> OnHandle(IEventRepository eventRepository)
        {
            var sessionFactory = new FakeSessionFactory(_idUser);
            return new CancelScenarioHandler<ISession>(eventRepository, sessionFactory);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CancelScenario When()
        {
            return BuildCmd.CancelScenario
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
