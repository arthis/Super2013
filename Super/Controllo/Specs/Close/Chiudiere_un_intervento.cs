using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Commands.Builders;
using Super.Controllo.Events;
using Super.Controllo.Events.Builders;
using Super.Controllo.Handlers;
using BuildCmd = Super.Controllo.Commands.Builders.Build;
using BuildEvt = Super.Controllo.Events.Builders.Build;

namespace Super.Controllo.Specs.Close
{
    public class Chiudiere_un_intervento : CommandBaseClass<CloseIntervento>
    {
        private Guid _Id = Guid.NewGuid();
        private DateTime _closingDate = DateTime.Now;
        private Guid _idUtente = Guid.NewGuid();

        protected override CommandHandler<CloseIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new CloseInterventoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoControlAllowed
                .Build(_Id, 1);
        }

        public override CloseIntervento When()
        {
            return BuildCmd.CloseIntervento
                        .By(_idUtente)
                        .When(_closingDate)
                        .Build(_Id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoClosed
                .By(_idUtente)
                .When(_closingDate)
                .Build(_Id,2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
