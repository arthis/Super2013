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
using Super.Controllo.Handlers;
using BuildCmd = Super.Controllo.Commands.Builders.Build;
using BuildEvt = Super.Controllo.Events.Builders.Build;

namespace Super.Controllo.Specs.Close
{
    public class Chiudiere_un_intervento_cui_controllo_non_era_permesso : CommandBaseClass<CloseIntervento>
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
          yield break;
        }

        public override CloseIntervento When()
        {
            var builder = new CloseInterventoBuilder();

            return BuildCmd.CloseIntervento
                .By(_idUtente)
                .When(_closingDate)
                .Build(_Id,0);
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
