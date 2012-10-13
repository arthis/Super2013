using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class SchedulazioneAmbUpdatedOfScenarioBuilder : IEventBuilder<SchedulazioneAmbUpdatedOfScenario>
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
        private int _quantity;
        private string _description;
        private Period _period;


        public SchedulazioneAmbUpdatedOfScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }


        public SchedulazioneAmbUpdatedOfScenarioBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenarioBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public SchedulazioneAmbUpdatedOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneAmbUpdatedOfScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneAmbUpdatedOfScenario(id,
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
                                                _quantity,
                                                _description);
        }
    }
}