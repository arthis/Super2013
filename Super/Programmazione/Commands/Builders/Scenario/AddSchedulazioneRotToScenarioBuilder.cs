using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public class AddSchedulazioneRotToScenarioBuilder : ICommandBuilder<AddSchedulazioneRotToScenario>
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

        public AddSchedulazioneRotToScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public AddSchedulazioneRotToScenarioBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public AddSchedulazioneRotToScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddSchedulazioneRotToScenario Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotToScenario(id,
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