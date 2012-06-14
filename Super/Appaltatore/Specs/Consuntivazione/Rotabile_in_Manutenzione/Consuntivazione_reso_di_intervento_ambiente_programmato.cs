using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;

namespace Super.Appaltatore.Specs.Consuntivazione.Rotabile_in_Manutenzione
{
    public class Consuntivazione_reso_di_intervento_rotabile_in_manutenzione_programmato : CommandBaseClass<ConsuntivareRotManReso>
    {
        //programmato
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

        //Cons
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        readonly DateTime _startCons = DateTime.Now.AddHours(-1);
        readonly DateTime _endCons = DateTime.Now.AddMinutes(-13);
        string _noteCons = "note";
        List<OggettoRotMan> oggettiCons = new List<OggettoRotMan>() { new OggettoRotMan() { Descrizione = "desc cons", IdTipoOggettoInterventoRotMan = Guid.NewGuid(), Quantita = 22 } };

        
        protected override CommandHandler<ConsuntivareRotManReso> OnHandle(IRepository repository)
        {
            return new ConsuntivareRotManResoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotManProgrammato()
            {
                Id = _id,
                End = _end,
                Headers = Headers,
                IdAreaIntervento = _idAreaIntervento,
                IdTipoIntervento = _idTipoIntervento,
                IdAppaltatore = _idAppaltatore,
                IdCategoriaCommerciale = _idCategoriaCommerciale,
                IdDirezioneRegionale = _idDirezioneRegionale,
                Note = _note,
                Oggetti = oggetti.ToArray(),
                Start = _start
            };
        }

        public override ConsuntivareRotManReso When()
        {
            return new ConsuntivareRotManReso()
            {
                End = _endCons,
                Start = _startCons,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatore,
                DataConsuntivazione = _dataConsuntivazione,
                Note = _noteCons,
               Headers = Headers,
                Oggetti = oggettiCons.ToArray()
            };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoConsuntivatoRotManReso()
            {
                End = _endCons,
                Start = _startCons,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatore,
                DataConsuntivazione = _dataConsuntivazione,
                Note = _noteCons,
                Headers = Headers,
                Oggetti = oggettiCons.ToArray()
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
