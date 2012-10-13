using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Domain.Intervento;
using Super.Programmazione.Domain.Schedulazione;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Programma;


namespace Super.Programmazione.Domain.Programma
{
    public class Programma : AggregateBase
    {
        private List<Guid> _schedulazioniRot = new List<Guid>();
        private List<Guid> _schedulazioniRotMan = new List<Guid>();
        private List<Guid> _schedulazioniAmb = new List<Guid>();

        private List<Guid> _interventiRot = new List<Guid>();
        private List<Guid> _interventiRotMan = new List<Guid>();
        private List<Guid> _interventiAmb = new List<Guid>();
 
        public Programma()
        {
            
        }

        public Programma(Guid idProgramma, Guid idScenario)
        {
            var evt = BuildEvt.ProgrammaCreated
                .ByScenario(idScenario);

            RaiseEvent(idProgramma,evt);
        }

        public void Apply(ProgrammaCreated e)
        {
            Id = e.Id;
        }

        public void AddSchedulazioneAmb(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {

            if(_schedulazioniAmb.Contains(idSchedulazione))
                throw new SchedulazioneAlreadyAddedToProgramma();

            var evt = BuildEvt.SchedulazioneAmbAddedToProgramma
                .ForAppaltatore(idAppaltatore)
                .ForSchedulazione(idSchedulazione)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDescription(description)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForQuantity(quantity)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note);

            RaiseEvent(evt);
        }

        public void Apply(SchedulazioneAmbAddedToProgramma evt)
        {
            _schedulazioniAmb.Add(evt.IdSchedulazione);
        }

        public void AddSchedulazioneRotMan(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            if (_schedulazioniRotMan.Contains(idSchedulazione))
                throw new SchedulazioneAlreadyAddedToProgramma();

            var evt = BuildEvt.SchedulazioneRotManAddedToProgramma
                .ForAppaltatore(idAppaltatore)
                .ForSchedulazione(idSchedulazione)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(evt);
            
        }

        public void Apply(SchedulazioneRotManAddedToProgramma evt)
        {
            _schedulazioniRotMan.Add(evt.IdSchedulazione);
        }

        public void AddSchedulazioneRot(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRot> oggetti, string convoglio, string rigaTurnoTreno, Treno trenoArrivo, Treno trenoPartenza, string turnoTreno)
        {
            if (_schedulazioniRot.Contains(idSchedulazione))
                throw new SchedulazioneAlreadyAddedToProgramma();

            var evt = BuildEvt.SchedulazioneRotAddedToProgramma
                .ForSchedulazione(idSchedulazione)
                .ForAppaltatore(idAppaltatore)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note)
                .ForConvoglio(convoglio)
                .WithOggetti(oggetti.ToMessage().ToArray())
                .WithRigaTurnoTreno(rigaTurnoTreno)
                .WithTrenoArrivo(trenoArrivo.ToMessage())
                .WithTrenoPartenza(trenoPartenza.ToMessage())
                .WithTurnoTreno(turnoTreno);

            RaiseEvent(evt);

        }

        public void Apply(SchedulazioneRotAddedToProgramma evt)
        {
            _schedulazioniRot.Add(evt.IdSchedulazione);
        }

        public SchedulazioneAmb CreateSchedulazioneAmb(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            var schedulazione = new SchedulazioneAmb(
                idProgramma,
                idAppaltatore,
                idCategoriaCommerciale,
                idCommittente,
                description,
                idDirezioneRegionale,
                idImpianto,
                idLotto,
                period,
                idPeriodoProgrammazione,
                quantity,
                idSchedulazione,
                workPeriod,
                idTipoIntervento,
                note);

            return schedulazione;

        }

        public SchedulazioneRot CreateSchedulazioneRot(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRot> oggetti, string convoglio, string rigaTurnoTreno, Treno trenoArrivo, Treno trenoPartenza, string turnoTreno)
        {
            var schedulazione = new SchedulazioneRot(
                idProgramma,
                idAppaltatore,
                idCategoriaCommerciale,
                idCommittente,
                idDirezioneRegionale,
                idImpianto,
                idLotto,
                period,
                idPeriodoProgrammazione,
                idSchedulazione,
                workPeriod,
                idTipoIntervento,
                note,
                oggetti,
                convoglio,
                rigaTurnoTreno,
                trenoArrivo,
                trenoPartenza,
                turnoTreno);

            return schedulazione;

        }

        public SchedulazioneRotMan CreateSchedulazioneRotMan(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            var schedulazione = new SchedulazioneRotMan(
                idProgramma,
                idAppaltatore,
                idCategoriaCommerciale,
                idCommittente,
                idDirezioneRegionale,
                idImpianto,
                idLotto,
                period,
                idPeriodoProgrammazione,
                idSchedulazione,
                workPeriod,
                idTipoIntervento,
                note,
                oggetti);

            return schedulazione;
        }

        public void AddInterventoAmb(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, int quantity, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            if (_interventiAmb.Contains(idIntervento))
                throw new InterventoAlreadyAddedToProgramma();

            var evt = BuildEvt.InterventoAmbAddedToProgramma
             .ForAppaltatore(idAppaltatore)
             .ForIntervento(idIntervento)
             .ForCategoriaCommerciale(idCategoriaCommerciale)
             .ForCommittente(idCommittente)
             .ForDescription(description)
             .ForDirezioneRegionale(idDirezioneRegionale)
             .ForImpianto(idImpianto)
             .ForLotto(idLotto)
             .ForPeriodoProgrammazione(idPeriodoProgrammazione)
             .ForQuantity(quantity)
             .ForWorkPeriod(workPeriod.ToMessage())
             .OfTipoIntervento(idTipoIntervento)
             .WithNote(note);

            RaiseEvent(evt);

        }

        public void Apply(InterventoAmbAddedToProgramma evt)
        {
            _interventiAmb.Add(evt.IdIntervento);
        }

        public void AddInterventoRot(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note, string convoglio, string rigaTurnoTreno, string turnoTreno, Treno trenoArrivo, Treno trenoPartenza, IEnumerable<OggettoRot> oggetti)
        {
            if (_interventiRot.Contains(idIntervento))
                throw new InterventoAlreadyAddedToProgramma();

            var evt = BuildEvt.InterventoRotAddedToProgramma
             .ForAppaltatore(idAppaltatore)
             .ForIntervento(idIntervento)
             .ForCategoriaCommerciale(idCategoriaCommerciale)
             .ForCommittente(idCommittente)
             .ForDirezioneRegionale(idDirezioneRegionale)
             .ForImpianto(idImpianto)
             .ForLotto(idLotto)
             .ForPeriodoProgrammazione(idPeriodoProgrammazione)
             .ForWorkPeriod(workPeriod.ToMessage())
             .OfTipoIntervento(idTipoIntervento)
             .WithNote(note)
             .ForConvoglio(convoglio)
             .WithOggetti(oggetti.ToMessage().ToArray())
             .WithRigaTurnoTreno(rigaTurnoTreno)
             .WithTrenoArrivo(trenoArrivo.ToMessage())
             .WithTrenoPartenza(trenoPartenza.ToMessage())
             .WithTurnoTreno(turnoTreno);

            RaiseEvent(evt);
        }

        public void Apply(InterventoRotAddedToProgramma evt)
        {
            _interventiRot.Add(evt.IdIntervento);
        }

        public void AddInterventoRotMan(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti)
        {
          if (_interventiRotMan.Contains(idIntervento))
                throw new InterventoAlreadyAddedToProgramma();

            var evt = BuildEvt.InterventoRotManAddedToProgramma
             .ForAppaltatore(idAppaltatore)
             .ForIntervento(idIntervento)
             .ForCategoriaCommerciale(idCategoriaCommerciale)
             .ForCommittente(idCommittente)
             .ForDirezioneRegionale(idDirezioneRegionale)
             .ForImpianto(idImpianto)
             .ForLotto(idLotto)
             .ForPeriodoProgrammazione(idPeriodoProgrammazione)
             .ForWorkPeriod(workPeriod.ToMessage())
             .OfTipoIntervento(idTipoIntervento)
             .WithNote(note)
             .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(evt);
        }

        public void Apply(InterventoRotManAddedToProgramma evt)
        {
            _interventiRotMan.Add(evt.IdIntervento);
        }

        public InterventoAmb CreateInterventoAmb(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, int quantity, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            var intervento = new InterventoAmb(
                idProgramma,
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

            return intervento;
        }

        public InterventoRot CreateInterventoRot(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRot> oggetti, string convoglio, string rigaTurnoTreno, Treno trenoArrivo, Treno trenoPartenza, string turnoTreno)
        {
            var intervento = new InterventoRot(
                idProgramma,
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
                oggetti,
                convoglio,
                rigaTurnoTreno,
                trenoArrivo,
                trenoPartenza,
                turnoTreno);

            return intervento;
        }

        public InterventoRotMan CreateInterventoRotMan(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            var intervento = new InterventoRotMan(
                idProgramma,
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

            return intervento;
        }
    }
}
