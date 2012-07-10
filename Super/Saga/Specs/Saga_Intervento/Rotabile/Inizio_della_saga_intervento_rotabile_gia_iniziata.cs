using System;
using System.Collections.Generic;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;
using CommonSpecs;
using Super.Saga.Handlers;
using Super.Programmazione.Events;
using BuildEvt = Super.Programmazione.Events.Builders.Build;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;


namespace Super.Saga.Specs.Saga_Intervento.Rotabile
{
    public class Inizio_della_saga_intervento_rotabile_gia_iniziata : SagaBaseClass<InterventoRotPianificato>
    {
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
        

        public override string ToDescription()
        {
            return "Une saga gia inziata non può essere iniziata di nuovo. vero?.";
        }

        protected override SagaHandler<InterventoRotPianificato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotPianificatoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotPianificato()
            {
                Period = _period,
                Id = _id,
                IdImpianto = _idImpianto,
                IdTipoIntervento = _idTipoIntervento,
                IdAppaltatore = _idAppaltatore,
                IdCategoriaCommerciale = _idCategoriaCommerciale,
                IdDirezioneRegionale = _idDirezioneRegionale,
                Note = _note,
                Oggetti = _oggetti.ToArray(),
                TrenoArrivo = _trenoArrivo,
                TrenoPartenza = _trenoPartenza,
                TurnoTreno = _turnoTreno,
                RigaTurnoTreno = _rigaTurnoTreno,
                Convoglio = _convoglio
            };
        }

        public override InterventoRotPianificato When()
        {
            return  new InterventoRotPianificato()
            {
                Period = _period,
                Id = _id,
                IdImpianto = _idImpianto,
                IdTipoIntervento = _idTipoIntervento,
                IdAppaltatore = _idAppaltatore,
                IdCategoriaCommerciale = _idCategoriaCommerciale,
                IdDirezioneRegionale = _idDirezioneRegionale,
                Note = _note,
                Oggetti = _oggetti.ToArray(),
                TrenoArrivo = _trenoArrivo,
                TrenoPartenza = _trenoPartenza,
                TurnoTreno = _turnoTreno,
                RigaTurnoTreno = _rigaTurnoTreno,
                Convoglio = _convoglio
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
