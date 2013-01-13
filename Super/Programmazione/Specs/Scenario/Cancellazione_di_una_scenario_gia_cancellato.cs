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
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class Cancellazione_di_un_scenario_gia_cancellato : CommandBaseClass<CancelScenario>
    {

        private Guid _id = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _description = "test";
        private Guid _idProgramma = Guid.NewGuid();
        

        protected override CommandHandler<CancelScenario> OnHandle(IEventRepository eventRepository)
        {
            return new CancelScenarioHandler(eventRepository);
        }

        
        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.UserAddedToSystem
                .WithFirstName("f")
                .WithLastName("l")
                .Build(_idUser, 1);
            yield return BuildEvt.ScenarioCreated
                .ForDescription(_description)
                .ForProgramma(_idProgramma)
                .ByUser(_idUser)
                .Build(_id,1);
            yield return BuildEvt.ScenarioCancelled
                .ByUser(_idUser)
                .Build(_id, 2);
        }

        public override CancelScenario When()
        {
            return BuildCmd.CancelScenario
                .Build(_id, 2, _idUser);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
