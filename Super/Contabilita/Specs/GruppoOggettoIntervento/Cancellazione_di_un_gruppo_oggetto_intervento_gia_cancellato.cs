using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.GruppoOggettoIntervento;
using Super.Contabilita.Events;
using BuildCmd = Super.Contabilita.Commands.Build;
using Super.Contabilita.Handlers.GruppoOggettoIntervento;

namespace Super.Contabilita.Specs.GruppoOggettoIntervento
{
    public class Cancellazione_di_un_gruppo_oggetto_intervento_gia_cancellato : CommandBaseClass<DeleteGruppoOggettoIntervento>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<DeleteGruppoOggettoIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteGruppoOggettoInterventoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.GruppoOggettoInterventoCreated
                .ForDescription(_description)
                .Build(_id,1);
            yield return BuildEvt.GruppoOggettoInterventoDeleted
                .Build(_id, 2);
        }

        public override DeleteGruppoOggettoIntervento When()
        {
            return BuildCmd.DeleteGruppoOggettoIntervento
                .Build(_id, 2);
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
