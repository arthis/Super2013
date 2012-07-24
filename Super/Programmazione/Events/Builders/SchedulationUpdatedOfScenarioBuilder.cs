using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders
{
    public class SchedulationUpdatedOfScenarioBuilder
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

        public SchedulationUpdatedOfScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulationUpdatedOfScenarioBuilder ForPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

    }

    public class SchedulationRotUpdatedOfScenarioBuilder : SchedulationUpdatedOfScenarioBuilder,
                                                   ICommandBuilder<SchedulationRotUpdatedOfScenario>
    {
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;

        public SchedulationRotUpdatedOfScenarioBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulationRotUpdatedOfScenarioBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public SchedulationRotUpdatedOfScenarioBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public SchedulationRotUpdatedOfScenarioBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public SchedulationRotUpdatedOfScenarioBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public SchedulationRotUpdatedOfScenarioBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public SchedulationRotUpdatedOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulationRotUpdatedOfScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulationRotUpdatedOfScenario(id,
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

    public class SchedulationRotManUpdatedOfScenarioBuilder : SchedulationUpdatedOfScenarioBuilder,
                                                   ICommandBuilder<SchedulationRotManUpdatedOfScenario>
    {
        private OggettoRotMan[] _oggetti;

        public SchedulationRotManUpdatedOfScenarioBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulationRotManUpdatedOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulationRotManUpdatedOfScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulationRotManUpdatedOfScenario(id,
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
                                                _oggetti);
        }
    }

    public class SchedulationAmbUpdatedOfScenarioBuilder : SchedulationUpdatedOfScenarioBuilder,
                                                   ICommandBuilder<SchedulationAmbUpdatedOfScenario>
    {
        private int _quantity;
        private string _description;


        public SchedulationAmbUpdatedOfScenarioBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public SchedulationAmbUpdatedOfScenarioBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public SchedulationAmbUpdatedOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulationAmbUpdatedOfScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulationAmbUpdatedOfScenario(id,
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
                                                _quantity,
                                                _description);
        }
    }
}