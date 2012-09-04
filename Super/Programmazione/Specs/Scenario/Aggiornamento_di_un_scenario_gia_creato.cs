using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Handlers.Scenario;
using Super.Programmazione.Commands;
using Super.Programmazione.Events;

namespace Super.Programmazione.Specs.Scenario
{
    public class Aggiornamento_di_un_scenario_gia_creato : CommandBaseClass<UpdateScenario>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        private string _descriptionUpdated = "test 2";


        protected override CommandHandler<UpdateScenario> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                                   .ForDescription(_description)
                                   .Build(_id, 1);
        }

        public override UpdateScenario When()
        {
            return BuildCmd.UpdateScenario
                            .ForDescription(_descriptionUpdated)
                            .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.ScenarioUpdated
                .ForDescription(_descriptionUpdated)
                .Build(_id, 2);

        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
