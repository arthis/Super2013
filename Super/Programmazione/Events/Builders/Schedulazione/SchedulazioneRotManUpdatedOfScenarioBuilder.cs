using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class SchedulazioneRotManUpdatedOfScenarioBuilder : IEventBuilder<SchedulazioneRotManUpdatedOfScenario>
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


        public SchedulazioneRotManUpdatedOfScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenarioBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulazioneRotManUpdatedOfScenario Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneRotManUpdatedOfScenario Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotManUpdatedOfScenario(id,
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