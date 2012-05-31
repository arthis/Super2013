using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;

namespace Super.Appaltatore.Specs.Consuntivazione.Rotabile_in_Manutenzione
{
    public class Consuntivazione_reso_di_intervento_rotabile_in_manutenzione_gia_consutivato_reso : CommandBaseClass<ConsuntivareRotManReso>
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

        //Cons 2
        readonly string _idInterventoAppaltatoreCons2 = "id intervento appaltatore Cons2";
        readonly DateTime _dataConsuntivazioneCons2 = DateTime.Now.AddMinutes(1);
        readonly DateTime _startCons2 = DateTime.Now.AddMinutes(-50);
        readonly DateTime _endCons2 = DateTime.Now.AddMinutes(-10);
        string _noteCons2 = "note  Cons2";
        List<OggettoRotMan> oggettiCons2 = new List<OggettoRotMan>() { new OggettoRotMan() { Descrizione = "desc cons2", IdTipoOggettoInterventoRotMan = Guid.NewGuid(), Quantita = 24 } };

        
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
            yield return new ConsuntivatoRotManReso()
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

        public override ConsuntivareRotManReso When()
        {
            return new ConsuntivareRotManReso()
            {
                End = _endCons2,
                Start = _startCons2,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatoreCons2,
                DataConsuntivazione = _dataConsuntivazioneCons2,
                Note = _noteCons2,
               Headers = Headers,
                Oggetti = oggettiCons2.ToArray()
            };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new ConsuntivatoRotManReso()
            {
                End = _endCons2,
                Start = _startCons2,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatoreCons2,
                DataConsuntivazione = _dataConsuntivazioneCons2,
                Note = _noteCons2,
                Headers = Headers,
                Oggetti = oggettiCons2.ToArray()
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
