using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Handlers.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class Aggiornamento_di_un_scenario_non_esistente : CommandBaseClass<UpdateScenario>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        protected override CommandHandler<UpdateScenario> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateScenario When()
        {

            return  BuildCmd.UpdateScenario
                         .ForDescription(_description)
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
