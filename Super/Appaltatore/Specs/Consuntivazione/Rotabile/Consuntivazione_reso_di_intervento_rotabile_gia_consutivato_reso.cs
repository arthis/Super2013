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

namespace Super.Appaltatore.Specs.Consuntivazione.Rotabile
{
    public class Consuntivazione_reso_di_intervento_rotabile_gia_consutivato_reso : CommandBaseClass<ConsuntivareRotReso>
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
        List<OggettoRot> oggetti = new List<OggettoRot>() { new OggettoRot() { Descrizione = "desc", IdTipoOggettoInterventoRot = Guid.NewGuid(), Quantita = 15 } };
        string _numeroTrenoArrivo = "numeroA";
        DateTime _dataTrenoArrivo = DateTime.Now.AddHours(9);
        string _numeroTrenoPartenza = "numeroP";
        DateTime _dataTrenoPartenza = DateTime.Now.AddHours(14);
        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        //Cons
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        readonly DateTime _startCons = DateTime.Now.AddHours(-1);
        readonly DateTime _endCons = DateTime.Now.AddMinutes(-13);
        string _noteCons = "note";
        List<OggettoRot> oggettiCons = new List<OggettoRot>() { new OggettoRot() { Descrizione = "desc cons", IdTipoOggettoInterventoRot = Guid.NewGuid(), Quantita = 22 } };
        string _numeroTrenoArrivoCons = "numeroA Cons";
        DateTime _dataTrenoArrivoCons = DateTime.Now.AddHours(10);
        string _numeroTrenoPartenzaCons = "numeroP Cons";
        DateTime _dataTrenoPartenzaCons = DateTime.Now.AddHours(15);
        string _turnoTrenoCons = "turno Cons";
        string _rigaTurnoTrenoCons = "rigaturno Cons";
        string _convoglioCons = "convoglio Cons";

        //Cons 2
        readonly string _idInterventoAppaltatoreCons2 = "id intervento appaltatore Cons2";
        readonly DateTime _dataConsuntivazioneCons2 = DateTime.Now.AddSeconds(-20);
        readonly DateTime _startCons2 = DateTime.Now.AddMinutes(-50);
        readonly DateTime _endCons2 = DateTime.Now.AddMinutes(-10);
        string _noteCons2 = "note  Cons2";
        List<OggettoRot> oggettiCons2 = new List<OggettoRot>() { new OggettoRot() { Descrizione = "desc cons2", IdTipoOggettoInterventoRot = Guid.NewGuid(), Quantita = 24 } };
        string _numeroTrenoArrivoCons2 = "numeroA Cons2";
        DateTime _dataTrenoArrivoCons2 = DateTime.Now.AddHours(11);
        string _numeroTrenoPartenzaCons2 = "numeroP Cons2";
        DateTime _dataTrenoPartenzaCons2 = DateTime.Now.AddHours(16);
        string _turnoTrenoCons2 = "turno Cons2";
        string _rigaTurnoTrenoCons2 = "rigaturno Cons2";
        string _convoglioCons2 = "convoglio Cons2";
        
        protected override CommandHandler<ConsuntivareRotReso> OnHandle(IRepository repository)
        {
            return new ConsuntivareRotResoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotProgrammato()
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
                NumeroTrenoArrivo = _numeroTrenoArrivo,
                DataTrenoArrivo = _dataTrenoArrivo,
                NumeroTrenoPartenza = _numeroTrenoPartenza,
                DataTrenoPartenza = _dataTrenoPartenza,
                TurnoTreno = _turnoTreno,
                RigaTurnoTreno = _rigaTurnoTreno,
                Convoglio = _convoglio,
                Start = _start
            };
            yield return new ConsuntivatoRotReso()
            {
                End = _endCons,
                Start = _startCons,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatore,
                DataConsuntivazione = _dataConsuntivazione,
                Note = _noteCons,
                Headers = Headers,
                Oggetti = oggettiCons.ToArray(),
                NumeroTrenoArrivo = _numeroTrenoArrivoCons,
                DataTrenoArrivo = _dataTrenoArrivoCons,
                NumeroTrenoPartenza = _numeroTrenoPartenzaCons,
                DataTrenoPartenza = _dataTrenoPartenzaCons,
                TurnoTreno = _turnoTrenoCons,
                RigaTurnoTreno = _rigaTurnoTrenoCons,
                Convoglio = _convoglioCons
            };
        }

        public override ConsuntivareRotReso When()
        {
            return new ConsuntivareRotReso()
            {
                End = _endCons2,
                Start = _startCons2,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatoreCons2,
                DataConsuntivazione = _dataConsuntivazioneCons2,
                Note = _noteCons2,
               Headers = Headers,
                Oggetti = oggettiCons2.ToArray(),
                NumeroTrenoArrivo = _numeroTrenoArrivoCons2,
                DataTrenoArrivo = _dataTrenoArrivoCons2,
                NumeroTrenoPartenza = _numeroTrenoPartenzaCons2,
                DataTrenoPartenza = _dataTrenoPartenzaCons2,
                TurnoTreno = _turnoTrenoCons2,
                RigaTurnoTreno = _rigaTurnoTrenoCons2,
                Convoglio = _convoglioCons2
            };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new ConsuntivatoRotReso()
            {
                End = _endCons2,
                Start = _startCons2,
                Id = _id,
                IdInterventoAppaltatore = _idInterventoAppaltatoreCons2,
                DataConsuntivazione = _dataConsuntivazioneCons2,
                Note = _noteCons2,
                Headers = Headers,
                Oggetti = oggettiCons2.ToArray(),
                NumeroTrenoArrivo = _numeroTrenoArrivoCons2,
                DataTrenoArrivo = _dataTrenoArrivoCons2,
                NumeroTrenoPartenza = _numeroTrenoPartenzaCons2,
                DataTrenoPartenza = _dataTrenoPartenzaCons2,
                TurnoTreno = _turnoTrenoCons2,
                RigaTurnoTreno = _rigaTurnoTrenoCons2,
                Convoglio = _convoglioCons2
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
