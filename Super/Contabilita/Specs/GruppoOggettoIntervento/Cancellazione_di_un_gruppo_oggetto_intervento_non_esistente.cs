using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.GruppoOggettoIntervento;
using Super.Contabilita.Handlers.GruppoOggettoIntervento;

namespace Super.Contabilita.Specs.GruppoOggettoIntervento
{
    public class Cancellazione_di_un_gruppo_oggetto_intervento_non_esistente : CommandBaseClass<DeleteGruppoOggettoIntervento>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteGruppoOggettoIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteGruppoOggettoInterventoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteGruppoOggettoIntervento When()
        {
            return BuildCmd.DeleteGruppoOggettoIntervento
                .Build(_id, 1);
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
