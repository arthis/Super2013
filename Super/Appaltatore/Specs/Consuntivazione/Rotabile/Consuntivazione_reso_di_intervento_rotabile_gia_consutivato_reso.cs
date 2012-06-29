using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
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
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desc", 15, Guid.NewGuid()) };
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        Treno _trenoArrivo = new Treno("numeroA", DateTime.Now.AddHours(9));
        Treno _trenoPartenza = new Treno("numeroP", DateTime.Now.AddHours(14));
        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        //Cons
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        string _noteCons = "note";
        List<OggettoRot> _oggettiCons = new List<OggettoRot>() { new OggettoRot("desc cons", 15, Guid.NewGuid()) };
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        Treno _trenoArrivoCons = new Treno("numeroA cons", DateTime.Now.AddHours(9));
        Treno _trenoPartenzaCons = new Treno("numeroP cons", DateTime.Now.AddHours(14)); string _turnoTrenoCons = "turno Cons";
        string _rigaTurnoTrenoCons = "rigaturno Cons";
        string _convoglioCons = "convoglio Cons";

        //Cons 2
        readonly string _idInterventoAppaltatoreCons2 = "id intervento appaltatore Cons2";
        readonly DateTime _dataConsuntivazioneCons2 = DateTime.Now.AddSeconds(-20);
        
        string _noteCons2 = "note  Cons2";
        List<OggettoRot> _oggettiCons2 = new List<OggettoRot>() { new OggettoRot("desc cons 2", 15, Guid.NewGuid()) };
        readonly WorkPeriod _periodCons2 = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        Treno _trenoArrivoCons2 = new Treno("numeroA cons", DateTime.Now.AddHours(9));
        Treno _trenoPartenzaCons2 = new Treno("numeroP cons", DateTime.Now.AddHours(14)); 
        string _turnoTrenoCons2 = "turno Cons2";
        string _rigaTurnoTrenoCons2 = "rigaturno Cons2";
        string _convoglioCons2 = "convoglio Cons2";
        
        protected override CommandHandler<ConsuntivareRotReso> OnHandle(IEventRepository eventRepository)
        {
            return new ConsuntivareRotResoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotProgrammato(
                _id,
                _idImpianto,
                _idTipoIntervento,
                _idAppaltatore,
                _idCategoriaCommerciale,
                _idDirezioneRegionale,
                _period,
                _note,
                _oggetti.ToArray(),
                _trenoPartenza,
                _trenoArrivo,
                _turnoTreno,
                _rigaTurnoTreno,
                _convoglio);
            yield return new InterventoConsuntivatoRotReso(
                _id,
                _idInterventoAppaltatore,
                _dataConsuntivazione,
                _periodCons,
                _noteCons,
                _oggettiCons.ToArray(),
                _trenoPartenzaCons,
                _trenoArrivoCons,
                _turnoTrenoCons,
                _rigaTurnoTrenoCons,
                _convoglioCons);
        }

        public override ConsuntivareRotReso When()
        {
            return new ConsuntivareRotReso(
              _id,
              _idInterventoAppaltatoreCons2,
              _dataConsuntivazioneCons2,
              _periodCons2,
              _noteCons2,
              _oggettiCons2.ToArray(),
              _trenoPartenzaCons2,
              _trenoArrivoCons2,
              _turnoTrenoCons2,
              _rigaTurnoTrenoCons2,
              _convoglioCons2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoConsuntivatoRotReso(
              _id,
              _idInterventoAppaltatoreCons2,
              _dataConsuntivazioneCons2,
              _periodCons2,
              _noteCons2,
              _oggettiCons2.ToArray(),
              _trenoPartenzaCons2,
              _trenoArrivoCons2,
              _turnoTrenoCons2,
              _rigaTurnoTrenoCons2,
              _convoglioCons2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
