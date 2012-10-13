using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Commands;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class Cambio_della_descrizione_di_un_scenario_gia_creato : CommandBaseClass<ChangeDescriptionScenario>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private Guid _idUser = Guid.NewGuid();
        private Guid _idProgramma = Guid.NewGuid();

        private string _descriptionUpdated = "test 2";


        protected override CommandHandler<ChangeDescriptionScenario> OnHandle(IEventRepository eventRepository)
        {
            return new ChangeDescriptionScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                                   .ForDescription(_description)
                                   .ForProgramma(_idProgramma)
                                   .ByUser(_idUser)
                                   .Build(_id, 1);
        }

        public override ChangeDescriptionScenario When()
        {
            return BuildCmd.ChangeDescriptionScenario
                            .ForDescription(_descriptionUpdated)
                            .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.DescriptionOfScenarioChanged
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
