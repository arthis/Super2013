using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;

namespace Super.Appaltatore.Specs.Intervento.Programmazione.Rotabile
{
    public class Programmazione_di_intervento_rotabile_non_esistente : CommandBaseClass<ProgrammareInterventoRot>
    {
        private Guid _Id = Guid.NewGuid();
        private Guid _IdAreaIntervento = Guid.NewGuid();
        private DateTime _Start = DateTime.Now.AddHours(12);
        private DateTime _End = DateTime.Now.AddHours(13);

        protected override CommandHandler<ProgrammareInterventoRot> OnHandle(IRepository repository)
        {
            return new ProgrammareInterventoRotHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override ProgrammareInterventoRot When()
        {
            return new ProgrammareInterventoRot()
            {
                End = _End,
                Start = _Start,
                Id = _Id,
                IdAreaIntervento = _IdAreaIntervento,
                Headers = _Headers
            };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoRotSchedulato()
            {
                End = _End,
                Start = _Start,
                Id = _Id,
                IdAreaIntervento = _IdAreaIntervento,
                Headers = _Headers
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
