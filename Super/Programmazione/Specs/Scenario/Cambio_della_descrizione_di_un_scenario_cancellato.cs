﻿using System;
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
    public class Cambio_della_descrizione_di_un_scenario_cancellato : CommandBaseClass<ChangeDescriptionScenario>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private Guid _idUser = Guid.NewGuid();
        private Guid _idProgramma = Guid.NewGuid();

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

            yield return BuildEvt.ScenarioCancelled
                                  .ByUser(_idUser)
                                  .Build(_id, 2);
        }

        public override ChangeDescriptionScenario When()
        {

            return  BuildCmd.ChangeDescriptionScenario
                         .ForDescription(_description)
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
            Assert.AreEqual(typeof(ScenarioCancelledDoNotAllowFurtherChanges), Caught.GetType());
        }


    }
}
