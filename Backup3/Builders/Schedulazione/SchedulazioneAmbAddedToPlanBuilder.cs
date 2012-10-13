using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class SchedulazioneAmbAddedToPlanBuilder : IEventBuilder<SchedulazioneAmbAddedToPlan>
    {
        private Guid _idPeriodoProgrammazione;
        private Guid _idPlan;
        private Guid _idCommittente;
        private Guid _idLotto;
        private Guid _idImpianto;
        private Guid _idTipoIntervento;
        private Guid _idAppaltatore;
        private Guid _idCategoriaCommerciale;
        private Guid _idDirezioneRegionale;
        private string _note;
        private WorkPeriod _workPeriod;
        private int _quantity;
        private string _description;
        private Period _period;


        public SchedulazioneAmbAddedToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }


        public SchedulazioneAmbAddedToPlanBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public SchedulazioneAmbAddedToPlanBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public SchedulazioneAmbAddedToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public SchedulazioneAmbAddedToPlan Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneAmbAddedToPlan(id,
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
                                                _quantity,
                                                _description);
        }
    }

}