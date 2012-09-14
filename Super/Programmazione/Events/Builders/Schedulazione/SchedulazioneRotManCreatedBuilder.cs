using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class SchedulazioneRotManCreatedBuilder : IEventBuilder<SchedulazioneRotManCreated>
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


        public SchedulazioneRotManCreatedBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public SchedulazioneRotManCreatedBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulazioneRotManCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneRotManCreated Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotManCreated(id,
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