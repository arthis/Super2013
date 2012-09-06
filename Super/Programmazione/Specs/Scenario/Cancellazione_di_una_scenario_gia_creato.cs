using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Events;
using Super.Programmazione.Commands;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class Cancellazione_di_una_scenario_gia_creato : CommandBaseClass<DeleteScenario>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        
        protected override CommandHandler<DeleteScenario> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ForDescription(_description)
                .Build(_id,1);
        }

        public override DeleteScenario When()
        {
            return BuildCmd.DeleteScenario
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.ScenarioDeleted
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
