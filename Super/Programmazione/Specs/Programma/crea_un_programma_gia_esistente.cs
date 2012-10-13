using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Programma;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Programma;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Programma
{
    public class crea_un_programma_gia_esistente : CommandBaseClass<CreateProgramma>
    {
        private readonly Guid _idProgramma = Guid.NewGuid();
        private Guid _idScenario = Guid.NewGuid();

        protected override CommandHandler<CreateProgramma> OnHandle(IEventRepository eventRepository)
        {
            return new CreateProgrammaHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ProgrammaCreated
                .ByScenario(_idScenario)
                .Build(_idProgramma, 1);
        }

        public override CreateProgramma When()
        {
            return BuildCmd.CreateProgramma
                .ByScenario(_idScenario)
                .Build(_idProgramma, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
