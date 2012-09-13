using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class SchedulazioneRotManAddedToPlanBuilder : IEventBuilder<SchedulazioneRotManAddedToPlan>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idPlan;
        protected Guid _idCommittente;
        protected Guid _idLotto;
        protected Guid _idImpianto;
        protected Guid _idTipoIntervento;
        protected Guid _idAppaltatore;
        protected Guid _idCategoriaCommerciale;
        protected Guid _idDirezioneRegionale;
        protected string _note;
        protected WorkPeriod _workPeriod;
        private OggettoRotMan[] _oggetti;
        private Period _period;


        public SchedulazioneRotManAddedToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public SchedulazioneRotManAddedToPlanBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public SchedulazioneRotManAddedToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneRotManAddedToPlan Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotManAddedToPlan(id,
                                                      commitId,
                                                      version,
                                                      _idPeriodoProgrammazione,
                                                      _idPlan,
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