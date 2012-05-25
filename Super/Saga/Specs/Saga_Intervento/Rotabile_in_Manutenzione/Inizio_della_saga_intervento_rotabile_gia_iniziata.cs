using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;
using CommonSpecs;
using Super.Saga.Handlers;
using Super.Schedulazione.Events;

namespace Super.Saga.Specs.Saga_Intervento.Rotabile_in_Manutenzione
{
    public class Inizio_della_saga_intervento_rotabile_in_manutenzione_gia_iniziata : SagaBaseClass<InterventoRotManSchedulato>
    {
        private Guid _Id = Guid.NewGuid();
        private Guid _IdAreaIntervento = Guid.NewGuid();
        private DateTime _Start = DateTime.Now.AddHours(12);
        private DateTime _End = DateTime.Now.AddHours(13);
        

        public override string ToDescription()
        {
            return "Une saga gia inziata non può essere iniziata di nuovo. vero?.";
        }

        protected override SagaHandler<InterventoRotManSchedulato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotManSchedulatoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotManSchedulato()
            {
                End = _End,
                Start = _Start,
                Id = _Id,
                IdAreaIntervento = _IdAreaIntervento,
                Headers = _Headers
            };
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
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(Exception), Caught.GetType());
        }


    }
}
