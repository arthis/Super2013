using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands;
using Super.Saga.Handlers;
using Super.Programmazione.Events;

namespace Super.Saga.Specs.Saga_Intervento.Rotabile
{
    public class consuntivazione_intervento : SagaBaseClass<IInterventoRotConsuntivato>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
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

        readonly string _idInterventoAppaltatore = "dsfsd";
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-18), DateTime.Now.AddMinutes(-16));
        private DateTime DataCons = DateTime.Now;
        string _noteCons = "note cons";
        List<OggettoRot> _oggettiCons = new List<OggettoRot>() { new OggettoRot("desc cons", 15, Guid.NewGuid()) };
        Treno _trenoArrivoCons = new Treno("numeroA", DateTime.Now.AddHours(10));
        Treno _trenoPartenzaCons = new Treno("numeroP", DateTime.Now.AddHours(15));
        string _turnoTrenoCons = "turno cons";
        string _rigaTurnoTrenoCons = "rigaturno cons";
        string _convoglioCons = "convoglio cons";

        public override string ToDescription()
        {
            return "Une saga gia inziata non può essere iniziata di nuovo. vero?.";
        }

        protected override SagaHandler<IInterventoRotConsuntivato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotConsuntivatoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotPianificato()
            {
                Period = _period,
                Id = _id,
                IdAreaIntervento = _idAreaIntervento,
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

        public override IInterventoRotConsuntivato When()
        {
            var builder = new InterventoConsuntivatoRotResoBuilder();

            return builder.ForConvoglio(_convoglioCons)
                .ForId(_id)
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .ForPeriod(_periodCons)
                .When(DataCons)
                .WithNote(_noteCons)
                .WithOggetti(_oggettiCons.ToArray())
                .WithRigaTurnoTreno(_rigaTurnoTrenoCons)
                .WithTrenoArrivo(_trenoArrivoCons)
                .WithTrenoPartenza(_trenoPartenzaCons)
                .WithTurnoTreno(_turnoTrenoCons)
                .Build();
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new AllowControlIntervento(_id);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
