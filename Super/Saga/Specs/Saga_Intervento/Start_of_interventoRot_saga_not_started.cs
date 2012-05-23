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

namespace Super.Saga.Specs.Saga_Intervento
{
    public class Start_of_interventoRot_saga_not_started : SagaBaseClass<InterventoRotSchedulato>
    {
        private Guid _Id = Guid.NewGuid();
        private Guid _IdAreaIntervento = Guid.NewGuid();
        private DateTime _Start = DateTime.Now.AddHours(12);
        private DateTime _End = DateTime.Now.AddHours(13);
        private Dictionary<string,object>  _Headers = new Dictionary<string, object>();

        public Start_of_interventoRot_saga_not_started()
        {
            _Headers[Message.CommitId] = Guid.NewGuid();
            _Headers[Message.CorrelationitId] = Guid.NewGuid();
        }

        protected override SagaHandler<InterventoRotSchedulato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotSchedulatoHandler(repository,bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override InterventoRotSchedulato When()
        {
            return new InterventoRotSchedulato()
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
            yield return new ProgrammareInterventoRot()
            {
                Id = _Id,
                End = _End,
                Headers = _Headers,
                IdAreaIntervento = _IdAreaIntervento,
                Start = _Start
            };
        }

        [Test]
        public void It_does_not_throw_an_Exception()
        {
            Assert.IsNull(Caught);
        }


    }
}
