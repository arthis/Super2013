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
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.GruppoOggettoIntervento;

namespace Super.Contabilita.Specs.GruppoOggettoIntervento
{
    public class Creazione_di_un_nuovo_gruppo_oggetto_intervento_gia_creato : CommandBaseClass<CreateGruppoOggettoIntervento>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        public override string ToDescription()
        {
            return "Creare un'appaltatore gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateGruppoOggettoIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new CreateGruppoOggettoInterventoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.GruppoOggettoInterventoCreated
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override CreateGruppoOggettoIntervento When()
        {
            return BuildCmd.CreateGruppoOggettoIntervento
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
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
