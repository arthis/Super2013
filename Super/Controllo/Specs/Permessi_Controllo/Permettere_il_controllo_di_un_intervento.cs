using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Events;
using Super.Controllo.Handlers;

namespace Super.Controllo.Specs.Permessi_Controllo
{
    public class Permettere_il_controllo_di_un_intervento : CommandBaseClass<AllowControlIntervento>
    {
        private Guid _Id = Guid.NewGuid();


        protected override CommandHandler<AllowControlIntervento> OnHandle(IRepository repository)
        {
            return new AllowControlInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override AllowControlIntervento When()
        {
            return new AllowControlIntervento()
            {
                Id = _Id
            };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoControlAllowed()
            {
                Id = _Id
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
