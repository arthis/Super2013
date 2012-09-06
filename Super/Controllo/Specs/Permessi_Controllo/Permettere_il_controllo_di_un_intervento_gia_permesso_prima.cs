using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Events;
using Super.Controllo.Handlers;
using BuildCmd = Super.Controllo.Commands.Builders.Build;

namespace Super.Controllo.Specs.Permessi_Controllo
{
    public class Permettere_il_controllo_di_un_intervento_gia_permesso_prima : CommandBaseClass<AllowControlIntervento>
    {
        private Guid _Id = Guid.NewGuid();


        public override string ToDescription()
        {
            return "non e possibile permettere di nuovo il controllo di un intervento gia permesso.";
        }

        protected override CommandHandler<AllowControlIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new AllowControlInterventoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoControlAllowed
                .Build(_Id, 1);
        }

        public override AllowControlIntervento When()
        {
            return BuildCmd.AllowControlIntervento
                .Build(_Id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione_perche_era_gia_permesso()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
