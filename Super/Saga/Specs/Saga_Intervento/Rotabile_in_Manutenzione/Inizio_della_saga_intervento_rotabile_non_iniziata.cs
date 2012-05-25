using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Commands;
using Super.Saga.Handlers;
using Super.Schedulazione.Events;

namespace Super.Saga.Specs.Saga_Intervento.Rotabile_in_Manutenzione
{
    public class Inizio_della_saga_intervento_rotabile_in_manutenzione_non_iniziata : SagaBaseClass<InterventoRotManSchedulato>
    {
        private Guid _Id = Guid.NewGuid();
        private Guid _IdAreaIntervento = Guid.NewGuid();
        private DateTime _Start = DateTime.Now.AddHours(12);
        private DateTime _End = DateTime.Now.AddHours(13);

        public override string ToDescription()
        {
            return "un inizo di saga normale";
        }

        protected override SagaHandler<InterventoRotManSchedulato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotManSchedulatoHandler(repository,bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override InterventoRotManSchedulato When()
        {
            return new InterventoRotManSchedulato()
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
            yield return new ProgrammareInterventoRotMan()
            {
                Id = _Id,
                End = _End,
                Headers = _Headers,
                IdAreaIntervento = _IdAreaIntervento,
                Start = _Start
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
