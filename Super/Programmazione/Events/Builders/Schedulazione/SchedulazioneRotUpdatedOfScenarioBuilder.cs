using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class SchedulazioneRotUpdatedOfScenarioBuilder : ICommandBuilder<SchedulazioneRotUpdatedOfScenario>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idScenario;
        protected Guid _idCommittente;
        protected Guid _idLotto;
        protected Guid _idImpianto;
        protected Guid _idTipoIntervento;
        protected Guid _idAppaltatore;
        protected Guid _idCategoriaCommerciale;
        protected Guid _idDirezioneRegionale;
        protected string _note;
        protected WorkPeriod _workPeriod;
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;


        public SchedulazioneRotUpdatedOfScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }
        
        public SchedulazioneRotUpdatedOfScenarioBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenarioBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public SchedulazioneRotUpdatedOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneRotUpdatedOfScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotUpdatedOfScenario(id,
                                                         commitId,
                                                         version,
                                                         _idPeriodoProgrammazione,
                                                         _idScenario,
                                                         _idCommittente,
                                                         _idLotto,
                                                         _idImpianto,
                                                         _idTipoIntervento,
                                                         _idAppaltatore,
                                                         _idCategoriaCommerciale,
                                                         _idDirezioneRegionale,
                                                         _workPeriod,
                                                         _note,
                                                         _oggetti,
                                                         _trenoPartenza,
                                                         _trenoArrivo,
                                                         _turnoTreno,
                                                         _rigaTurnoTreno,
                                                         _convoglio);
        }
    }
}