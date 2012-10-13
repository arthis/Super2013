using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Domain.Schedulazione;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Domain.Programma
{
    public class Scenario : AggregateBase
    {
        private bool _cancelled;
        private bool _promoted;
        private Guid _IdProgramma;

        public Scenario()
        {
        }

        public Scenario(Guid id, Guid userId, string description, Guid idProgramma)
        {
            var evt = BuildEvt.ScenarioCreated
                .ByUser(userId)
                .ForDescription(description)
                .ForProgramma(idProgramma);

            RaiseEvent(id, evt);
        }

        public void Apply(ScenarioCreated e)
        {
            Id = e.Id;
            _IdProgramma = e.IdProgramma;
        }

        public void ChangeDescription(string description)
        {
            if (_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var evt = BuildEvt.DescriptionOfScenarioChanged
               .ForDescription(description);

            RaiseEvent(evt);
        }

        public void Apply(DescriptionOfScenarioChanged e)
        {
            //do nothing
        }


        public void Cancel(Guid userId)
        {
            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            if (!_cancelled)
            {
                var evt = BuildEvt.ScenarioCancelled
                    .ByUser(userId);

                RaiseEvent(evt);
            }
        }

        public void Apply(ScenarioCancelled e)
        {
            _cancelled = true;
        }


        public void PromoteToPlan(Guid userId,DateTime promotingDate, Guid idPlan)
        {
            if (_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var evt = BuildEvt.ScenarioPromotedToPlan
                .ByUser(userId)
                .ForPlan(idPlan)
                .WhenPromotionDate(promotingDate);

            RaiseEvent(evt);

        }

        public void Apply(ScenarioPromotedToPlan e)
        {
            _promoted = true;

        }


        public void AddSchedulazioneAmb(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            if (_cancelled)
                throw  new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var evt = BuildEvt.SchedulazioneAmbAddedToScenario
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(_IdProgramma)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDescription(description)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForQuantity(quantity)
                .ForSchedulazione(idSchedulazione)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note);

            RaiseEvent(idSchedulazione, evt);

        }

        public void Apply(SchedulazioneAmbAddedToScenario e)
        {


        }

        public void AddSchedulazioneRot(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione,  Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, string convoglio, string rigaTurnoTreno, string turnoTreno, Treno trenoArrivo, Treno trenoPartenza, IEnumerable< OggettoRot> oggetti)
        {
            if (_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var evt = BuildEvt.SchedulazioneRotAddedToScenario
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(_IdProgramma)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForSchedulazione(idSchedulazione)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note)
                .ForConvoglio(convoglio)
                .WithRigaTurnoTreno(rigaTurnoTreno)
                .WithTurnoTreno(turnoTreno)
                .WithTrenoArrivo(trenoArrivo.ToMessage())
                .WithTrenoPartenza(trenoPartenza.ToMessage())
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(Id, evt);
        }

        public void Apply(SchedulazioneRotAddedToScenario e)
        {


        }


        public void AddSchedulazioneRotMan(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            if (_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var evt = BuildEvt.SchedulazioneRotManAddedToScenario
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(_IdProgramma)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForSchedulazione(idSchedulazione)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(evt);

        }

        public void Apply(SchedulazioneRotManAddedToScenario e)
        {

        }

        public Programma CreateProgramma()
        {
            var programma = new Programma(_IdProgramma,Id);

            return programma;
        }

        public Plan CreatePlan(Guid idPlan)
        {
            if (_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (!_promoted)
                throw new ScenarioNotPromotedCannotCreatePlan();

            var plan = new Plan(idPlan, Id, _IdProgramma);

            return plan;
        }
    }
}
