using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Intervento;

namespace Super.Programmazione.Events.Builders.Intervento
{
    public class InterventoRotManScheduledBuilder : IEventBuilder<InterventoRotManScheduled>
    {
        protected Guid _idPeriodoProgrammazione;
        protected Guid _idPlan;
        protected Guid _idSchedulazione;
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
        private Guid _idInterventoGeneration;


        public InterventoRotManScheduledBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public InterventoRotManScheduledBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public InterventoRotManScheduledBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public InterventoRotManScheduledBuilder ForInterventoGeneration(Guid idInterventoGeneration)
        {
            _idInterventoGeneration = idInterventoGeneration;
            return this;
        }

        public InterventoRotManScheduledBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public InterventoRotManScheduledBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public InterventoRotManScheduledBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoRotManScheduledBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotManScheduledBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoRotManScheduledBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoRotManScheduledBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoRotManScheduledBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoRotManScheduledBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public InterventoRotManScheduledBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }


        public InterventoRotManScheduled Build(Guid id, long version)
        {
            var evt = new InterventoRotManScheduled(id, Guid.NewGuid(),
                                                    version,
                                                    _idPeriodoProgrammazione,
                                                    _idPlan,
                                                    _idSchedulazione,
                                                    _idInterventoGeneration,
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

            return evt;
        }

    }
}