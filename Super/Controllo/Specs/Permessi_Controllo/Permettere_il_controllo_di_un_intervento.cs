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
using Super.Controllo.Commands.Consuntivazione;
using Super.Controllo.Events;
using Super.Controllo.Handlers;

namespace Super.Controllo.Specs.Permessi_Controllo
{
    public class Permettere_il_controllo_di_un_intervento : CommandBaseClass<AllowControlIntervento>
    {
        private Guid _Id = Guid.NewGuid();


        protected override CommandHandler<AllowControlIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new AllowControlInterventoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override AllowControlIntervento When()
        {
            return BuildCmd.AllowControlIntervento
                .Build(_Id,0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoControlAllowed
                .Build(_Id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
