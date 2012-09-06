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
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.GruppoOggettoIntervento;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.GruppoOggettoIntervento;

namespace Super.Contabilita.Specs.GruppoOggettoIntervento
{
    public class Aggiornamento_di_un_gruppo_oggetto_intervento_non_esistente : CommandBaseClass<UpdateGruppoOggettoIntervento>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        protected override CommandHandler<UpdateGruppoOggettoIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateGruppoOggettoInterventoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateGruppoOggettoIntervento When()
        {

            return  BuildCmd.UpdateGruppoOggettoIntervento
                         .ForDescription(_description)
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
