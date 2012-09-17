using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Events.Builders.Scenario
{
    public class SchedulazioneRotManAddedToScenarioBuilder : IEventBuilder<SchedulazioneRotManAddedToScenario>
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


        public SchedulazioneRotManAddedToScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public SchedulazioneRotManAddedToScenarioBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulazioneRotManAddedToScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneRotManAddedToScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotManAddedToScenario(id,
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