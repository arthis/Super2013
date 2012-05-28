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
using Super.Appaltatore.Commands;
using Super.Saga.Handlers;
using Super.Programmazione.Events;

namespace Super.Saga.Specs.Saga_Intervento.Rotabile_in_Manutenzione
{
    public class Inizio_della_saga_intervento_rotabile_in_manutenzione_non_iniziata : SagaBaseClass<InterventoRotManPianificato>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly DateTime _start = DateTime.Now.AddHours(12);
        readonly DateTime _end = DateTime.Now.AddHours(13);
        List<OggettoRotMan> oggetti = new List<OggettoRotMan>() { new OggettoRotMan() { Descrizione = "desc", IdTipoOggettoInterventoRotMan = Guid.NewGuid(), Quantita = 15 } };
        string _note = "note";

        public override string ToDescription()
        {
            return "un inizo di saga normale";
        }

        protected override SagaHandler<InterventoRotManPianificato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotManPianificatoHandler(repository,bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override InterventoRotManPianificato When()
        {
            return new InterventoRotManPianificato()
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
                           Oggetti = oggetti.ToArray(),
                           Headers = _Headers
                       };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new ProgrammareInterventoRotMan()
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
                Oggetti = oggetti.ToArray(),
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
