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
using BuildEvtProg = Super.Programmazione.Events.Builders.Build;
using BuildEvtApp = Super.Appaltatore.Events.Builders.Build;
using BuildCmdCtrl = Super.Controllo.Commands.Builders.Build;


namespace Super.Saga.Specs.Saga_Intervento.Rotabile
{
    public class consuntivazione_intervento : SagaBaseClass<InterventoConsuntivatoRotReso>
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

        protected override SagaHandler<InterventoConsuntivatoRotReso> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoConsuntivatoRotResoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvtProg.InterventoRotPianificato
              .ForPeriod(_period)
              .ForImpianto(_idImpianto)
              .OfType(_idTipoIntervento)
              .ForAppaltatore(_idAppaltatore)
              .OfCategoriaCommerciale(_idCategoriaCommerciale)
              .OfDirezioneRegionale(_idDirezioneRegionale)
              .WithOggetti(_oggetti.ToArray())
              .WithTrenoArrivo(_trenoArrivo)
              .WithTrenoPartenza(_trenoPartenza)
              .WithTurnoTreno(_turnoTreno)
              .WithRigaTurnoTreno(_rigaTurnoTreno)
              .ForConvoglio(_convoglio)
              .WithNote(_note)
              .Build(_id, 1);
        }

        public override InterventoConsuntivatoRotReso When()
        {
            

            return BuildEvtApp.InterventoConsuntivatoRotReso
                .ForConvoglio(_convoglioCons)
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .ForPeriod(_periodCons)
                .When(DataCons)
                .WithNote(_noteCons)
                .WithOggetti(_oggettiCons.ToArray())
                .WithRigaTurnoTreno(_rigaTurnoTrenoCons)
                .WithTrenoArrivo(_trenoArrivoCons)
                .WithTrenoPartenza(_trenoPartenzaCons)
                .WithTurnoTreno(_turnoTrenoCons)
                .Build(_id,24);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildCmdCtrl.AllowControlIntervento
                                     .Build(_id, 0);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
