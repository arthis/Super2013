﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands;

using Super.Programmazione.Events;
using Super.Saga.Handlers.Consuntivazione;
using Super.Saga.Handlers.Intervento;

namespace Super.Saga.Specs.Consuntivazione.Rotabile
{
    public class consuntivazione_non_reso_di_un_intervento_rotabile : SagaBaseClass<InterventoRotConsuntivatoNonReso>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly Guid _idPeriodoProgrammazione = Guid.NewGuid();
        readonly Guid _idProgramma = Guid.NewGuid();
        readonly Guid _idLotto = Guid.NewGuid();
        readonly Guid _idCommittente = Guid.NewGuid();
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desc", 15, Guid.NewGuid(), Guid.NewGuid()) };
        readonly WorkPeriod _workPeriod = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
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
        List<OggettoRot> _oggettiCons = new List<OggettoRot>() { new OggettoRot("desc cons 2", 15, Guid.NewGuid(), Guid.NewGuid()) };
        private Guid _idCausaleAppaltatore= Guid.NewGuid();

        public override string ToDescription()
        {
            return "Une saga gia inziata non può essere iniziata di nuovo. vero?.";
        }

        protected override SagaHandler<InterventoRotConsuntivatoNonReso> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotConsuntivatoNonResoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoRotCreated
              .ForWorkPeriod(_workPeriod)
              .ForImpianto(_idImpianto)
              .OfTipoIntervento(_idTipoIntervento)
              .ForAppaltatore(_idAppaltatore)
              .ForCategoriaCommerciale(_idCategoriaCommerciale)
              .ForDirezioneRegionale(_idDirezioneRegionale)
              .WithOggetti(_oggetti.ToArray())
              .WithTrenoArrivo(_trenoArrivo)
              .WithTrenoPartenza(_trenoPartenza)
              .WithTurnoTreno(_turnoTreno)
              .WithRigaTurnoTreno(_rigaTurnoTreno)
              .ForConvoglio(_convoglio)
              .WithNote(_note)
              .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
              .ForCommittente(_idCommittente)
              .ForProgramma(_idProgramma)
              .ForLotto(_idLotto)
              .Build(_id, 1);
        }

        public override InterventoRotConsuntivatoNonReso When()
        {

            return Appaltatore.Events.BuildEvt.InterventoRotConsuntivatoNonReso
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .When(DataCons)
                .WithNote(_noteCons)
                .Because(_idCausaleAppaltatore)
                .Build(_id, 24);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildCmd.ConsuntivareNonResoInterventoRot
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .When(DataCons)
                .WithNote(_noteCons)
                .Because(_idCausaleAppaltatore)
                .Build(_id);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
