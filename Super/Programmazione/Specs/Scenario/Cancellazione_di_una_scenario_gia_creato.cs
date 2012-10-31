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
    public class Cancellazione_di_una_scenario_gia_creato : CommandBaseClass<CancelScenario>
    {
        private Guid _id = Guid.NewGuid();
        private Guid _idUserCreating = Guid.NewGuid();
        private Guid _idUserCancelling = Guid.NewGuid();
        private string _description = "test";
        private Guid _idProgramma = Guid.NewGuid();
        
        protected override CommandHandler<CancelScenario> OnHandle(IEventRepository eventRepository)
        {
            return new CancelScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.UserAddedToSystem
                .WithFirstName("t")
                .WithLastName("l")
                .Build(_idUserCancelling,1);
            yield return BuildEvt.ScenarioCreated
                .ForDescription(_description)
                .ForProgramma(_idProgramma)
                .ByUser(_idUserCreating)
                .Build(_id,1);
        }

        public override CancelScenario When()
        {
            return BuildCmd.CancelScenario
                .Build(_id, 1,_idUserCancelling);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.ScenarioCancelled
                .ByUser(_idUserCancelling)
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
