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
    public class Consuntivazione_reso_di_intervento_rotabile_programmato : CommandBaseClass<ConsuntivareRotReso>
    {
        //programmato
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desc", 15 , Guid.NewGuid())};
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        Treno _trenoArrivo = new Treno("numeroA" , DateTime.Now.AddHours(9));
        Treno _trenoPartenza = new Treno("numeroP", DateTime.Now.AddHours(14));
        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        //Cons
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        string _noteCons = "note";
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-10));
        List<OggettoRot> _oggettiCons = new List<OggettoRot>() { new OggettoRot("desccons", 22, Guid.NewGuid()) };
        Treno _trenoArrivoCons = new Treno("numeroA cons", DateTime.Now.AddHours(10));
        Treno _trenoPartenzaCons = new Treno("numeroP cons", DateTime.Now.AddHours(15));
        string _turnoTrenoCons = "turno Cons";
        string _rigaTurnoTrenoCons = "rigaturno Cons";
        string _convoglioCons = "convoglio Cons";
        
        protected override CommandHandler<ConsuntivareRotReso> OnHandle(IRepository repository)
        {
            return new ConsuntivareRotResoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotProgrammato(
                _id,
                _idAreaIntervento,
                _idTipoIntervento,
                _idAppaltatore,
                _idCategoriaCommerciale,
                _idDirezioneRegionale,
                _period,
                _noteCons,
                _oggetti.ToArray(),
                _trenoPartenza,
                _trenoArrivo,
                _turnoTrenoCons,
                _rigaTurnoTrenoCons,
                _convoglioCons);
        }

        public override ConsuntivareRotReso When()
        {
            return new ConsuntivareRotReso(
                _id,
                _idInterventoAppaltatore,
                _dataConsuntivazione,
                _periodCons,
                _noteCons,
                _oggettiCons.ToArray(),
                _trenoPartenzaCons,
                _trenoArrivoCons,
                _turnoTreno,
                _rigaTurnoTreno,
                _convoglio);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new InterventoConsuntivatoRotReso(
                _id,
                _idInterventoAppaltatore,
                _dataConsuntivazione,
                _period,
                _note,
                _oggetti.ToArray(),
                _trenoPartenza,
                _trenoArrivo,
                _turnoTreno,
                _rigaTurnoTreno,
                _convoglio);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
