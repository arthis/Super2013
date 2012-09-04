using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Handlers.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class Cancellazione_di_un_scenario_non_esistente : CommandBaseClass<DeleteScenario>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteScenario> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteScenario When()
        {
            return BuildCmd.DeleteScenario
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
