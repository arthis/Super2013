using System;
using System.Collections.Generic;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands;
using Super.Saga.Handlers;
using Super.Programmazione.Events;

namespace Super.Saga.Specs.Saga_Intervento.Ambiente
{
    public class consuntivazione_intervento : SagaBaseClass<IInterventoAmbConsuntivato>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly DateTime _start = DateTime.Now.AddHours(12);
        readonly DateTime _end = DateTime.Now.AddHours(13);
        private int _quantita = 12;
        private string _descrizione = "desc";
        string _note = "note";
        

        public override string ToDescription()
        {
            return "";
        }

        protected override SagaHandler<IInterventoAmbConsuntivato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoAmbConsuntivatoHandler(repository, bus);
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

        public override IInterventoAmbConsuntivato When()
        {
            return new InterventoConsuntivatoAmbReso()
                       {
                           End = _end
                           , Start = _start
                           , Id = _id
                           , Quantita = _quantita
                           , Descrizione = _descrizione
                           , Note = _note
                           , Headers = _Headers
                       };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new AllowControlIntervento()
                      {
                           Id = _id
                      };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
