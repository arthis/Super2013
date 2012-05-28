using System;
using System.Collections.Generic;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;
using CommonSpecs;
using Super.Saga.Handlers;
using Super.Programmazione.Events;

namespace Super.Saga.Specs.Saga_Intervento.Ambabile
{
    public class Inizio_della_saga_intervento_ambiente_gia_iniziata : SagaBaseClass<InterventoAmbPianificato>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly DateTime _start = DateTime.Now.AddHours(12);
        readonly DateTime _end = DateTime.Now.AddHours(13);
        string _note = "note";
        

        public override string ToDescription()
        {
            return "Une saga gia inziata non può essere iniziata di nuovo. vero?.";
        }

        protected override SagaHandler<InterventoAmbPianificato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoAmbPianificatoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoAmbPianificato()
            {
                End = _end,
                Start = _start,
                Id = _id,
                IdAreaIntervento = _idAreaIntervento,
                IdTipoIntervento = _idTipoIntervento,
                IdAppaltatore = _idAppaltatore,
                IdCategoriaCommerciale = _idCategoriaCommerciale,
                IdDirezioneRegionale = _idDirezioneRegionale,
                Note = _note,
                Headers = _Headers
            };
        }

        public override InterventoAmbPianificato When()
        {
            return new InterventoAmbPianificato()
                       {
                           End = _end,
                           Start = _start,
                           Id = _id,
                           IdAreaIntervento = _idAreaIntervento,
                           IdTipoIntervento = _idTipoIntervento,
                           IdAppaltatore = _idAppaltatore,
                           IdCategoriaCommerciale = _idCategoriaCommerciale,
                           IdDirezioneRegionale = _idDirezioneRegionale,
                           Note = _note,
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
