using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders
{
    public class SchedulationAddedToScenarioBuilder
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

        public SchedulationAddedToScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulationAddedToScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public SchedulationAddedToScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulationAddedToScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulationAddedToScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulationAddedToScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulationAddedToScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulationAddedToScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulationAddedToScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulationAddedToScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulationAddedToScenarioBuilder ForPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

    }

    public class SchedulationRotAddedToScenarioBuilder : SchedulationAddedToScenarioBuilder,
                                                   ICommandBuilder<SchedulationRotAddedToScenario>
    {
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;

        public SchedulationRotAddedToScenarioBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulationRotAddedToScenarioBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public SchedulationRotAddedToScenarioBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public SchedulationRotAddedToScenarioBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public SchedulationRotAddedToScenarioBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public SchedulationRotAddedToScenarioBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public SchedulationRotAddedToScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulationRotAddedToScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulationRotAddedToScenario(id,
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

    public class SchedulationRotManAddedToScenarioBuilder : SchedulationAddedToScenarioBuilder,
                                                   ICommandBuilder<SchedulationRotManAddedToScenario>
    {
        private OggettoRotMan[] _oggetti;

        public SchedulationRotManAddedToScenarioBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulationRotManAddedToScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulationRotManAddedToScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulationRotManAddedToScenario(id,
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

    public class SchedulationAmbAddedToScenarioBuilder : SchedulationAddedToScenarioBuilder,
                                                   ICommandBuilder<SchedulationAmbAddedToScenario>
    {
        private int _quantity;
        private string _description;


        public SchedulationAmbAddedToScenarioBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public SchedulationAmbAddedToScenarioBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public SchedulationAmbAddedToScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulationAmbAddedToScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulationAmbAddedToScenario(id,
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