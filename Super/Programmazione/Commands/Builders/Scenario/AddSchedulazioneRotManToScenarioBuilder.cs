using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Scenario
{
    public class AddSchedulazioneRotManToScenarioBuilder : ICommandBuilder<AddSchedulazioneRotManToScenario>
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
        protected Period _period;
        private OggettoRotMan[] _oggetti;

        public AddSchedulazioneRotManToScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public AddSchedulazioneRotManToScenarioBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public AddSchedulazioneRotManToScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddSchedulazioneRotManToScenario Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotManToScenario(id,
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
                                                        _period,
                                                        _note,
                                                        _oggetti);
        }
    }
}