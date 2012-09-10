using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class SchedulazioneRotAddedToScenarioBuilder : ICommandBuilder<SchedulazioneRotAddedToScenario>
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


        public SchedulazioneRotAddedToScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public SchedulazioneRotAddedToScenarioBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public SchedulazioneRotAddedToScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneRotAddedToScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotAddedToScenario(id,
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