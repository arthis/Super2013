using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Intervento;

namespace Super.Programmazione.Events.Builders.Intervento
{
    public class InterventoAmbScheduledBuilder :  IEventBuilder<InterventoAmbScheduled>
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
        private int _quantity;
        private string _description;
        private Guid _idInterventoGeneration;

        public InterventoAmbScheduledBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public InterventoAmbScheduledBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public InterventoAmbScheduledBuilder ForSchedulazione(Guid idSchedulazione)
        {
            _idSchedulazione = idSchedulazione;
            return this;
        }

        public InterventoAmbScheduledBuilder ForInterventoGeneration(Guid idInterventoGeneration)
        {
            _idInterventoGeneration = idInterventoGeneration;
            return this;
        }

        public InterventoAmbScheduledBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public InterventoAmbScheduledBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public InterventoAmbScheduledBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoAmbScheduledBuilder OfType(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoAmbScheduledBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoAmbScheduledBuilder OfCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoAmbScheduledBuilder OfDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoAmbScheduledBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoAmbScheduledBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public InterventoAmbScheduledBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public InterventoAmbScheduledBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


        public InterventoAmbScheduled Build(Guid id, long version)
        {
            var evt = new InterventoAmbScheduled(id, Guid.NewGuid(),
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
                                                 _quantity,
                                                 _description);

            return evt;
        }

    }


    
}
