using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Commands.Builders;
using Super.Controllo.Events;
using Super.Controllo.Events.Builders;
using Super.Controllo.Handlers;

namespace Super.Controllo.Specs.Close
{
    public class Chiudiere_un_intervento : CommandBaseClass<CloseIntervento>
    {
        private Guid _Id = Guid.NewGuid();
        private DateTime _closingDate = DateTime.Now;
        private Guid _idUtente = Guid.NewGuid();

        protected override CommandHandler<CloseIntervento> OnHandle(IRepository repository)
        {
            return new CloseInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoControlAllowed()
            {
                Id = _Id
            };
        }

        public override CloseIntervento When()
        {
            var builder = new CloseInterventoBuilder();

            return builder.ForId(_Id)
                .By(_idUtente)
                .When(_closingDate)
                .Build();
        }

        public override IEnumerable<IMessage> Expect()
        {
            var builder = new InterventoClosedBuilder();

            yield return builder.ForId(_Id)
                .By(_idUtente)
                .When(_closingDate)
                .Build();
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
