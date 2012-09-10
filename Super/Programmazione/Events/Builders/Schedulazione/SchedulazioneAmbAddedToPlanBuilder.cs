using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class SchedulazioneAmbAddedToPlanBuilder : ICommandBuilder<SchedulazioneAmbAddedToPlan>
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
        private int _quantity;
        private string _description;


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
                                                _note,
                                                _quantity,
                                                _description);
        }
    }

}