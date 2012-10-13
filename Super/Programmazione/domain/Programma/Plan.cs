using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Domain.Intervento;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Plan;

namespace Super.Programmazione.Domain.Programma
{
    public class Plan : AggregateBase
    {
        private Guid _idProgramma;
        private bool _cancelled;

        public Plan()
        {
            
        }

        public Plan(Guid idPlan, Guid idScenario, Guid idProgramma)
        {
            var evt = BuildEvt.PlanCreated
                .ByScenario(idScenario)
                .ForProgramma(idProgramma);

            RaiseEvent(idPlan, evt);
        }

        public void Apply(PlanCreated e)
        {
            Id = e.Id;
            _idProgramma = e.IdProgramma;
        }

        public void AddSchedulazioneAmb(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            if (_cancelled)
                throw new PlanCancelledDoNotAllowFurtherChanges();

            var evt = BuildEvt.SchedulazioneAmbAddedToPlan
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(_idProgramma)
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

            RaiseEvent(evt);

        }



        public void AddSchedulazioneRot(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, string convoglio, string rigaTurnoTreno, string turnoTreno, Treno trenoArrivo, Treno trenoPartenza, IEnumerable<OggettoRot> oggetti)
        {
            if (_cancelled)
                throw new PlanCancelledDoNotAllowFurtherChanges();

            var evt = BuildEvt.SchedulazioneRotAddedToPlan
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(_idProgramma)
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

            RaiseEvent(evt);
        }

        
        public void AddSchedulazioneRotMan(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            if (_cancelled)
                throw new PlanCancelledDoNotAllowFurtherChanges();

            var evt = BuildEvt.SchedulazioneRotManAddedToPlan
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(_idProgramma)
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

        public void AddInterventoAmb(Programma programma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, int quantity, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            if (_cancelled)
                throw new PlanCancelledDoNotAllowFurtherChanges();

            programma.AddInterventoAmb(
                _idProgramma,
                idAppaltatore,
                idCategoriaCommerciale,
                idCommittente,
                description,
                idDirezioneRegionale,
                idImpianto,
                idLotto,
                idPeriodoProgrammazione,
                quantity,
                idIntervento,
                workPeriod,
                idTipoIntervento,
                note);
        }

        public void AddInterventoRot(Programma programma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note, string convoglio, string rigaTurnoTreno, string turnoTreno, Treno trenoArrivo, Treno trenoPartenza, IEnumerable<OggettoRot> oggetti)
        {
            if (_cancelled)
                throw new PlanCancelledDoNotAllowFurtherChanges();

            programma.AddInterventoRot(
                _idProgramma,
                idAppaltatore,
                idCategoriaCommerciale,
                idCommittente,
                idDirezioneRegionale,
                idImpianto,
                idLotto,
                idPeriodoProgrammazione,
                idIntervento,
                workPeriod,
                idTipoIntervento,
                note,
                convoglio,
                rigaTurnoTreno,
                turnoTreno,
                trenoArrivo,
                trenoPartenza,
                oggetti);
        }

        public void AddInterventoRotMan(Programma programma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            if (_cancelled)
                throw new PlanCancelledDoNotAllowFurtherChanges();

            programma.AddInterventoRotMan(
                _idProgramma,
                idAppaltatore,
                idCategoriaCommerciale,
                idCommittente,
                idDirezioneRegionale,
                idImpianto,
                idLotto,
                idPeriodoProgrammazione,
                idIntervento,
                workPeriod,
                idTipoIntervento,
                note,
                oggetti);

        }
    }
}
