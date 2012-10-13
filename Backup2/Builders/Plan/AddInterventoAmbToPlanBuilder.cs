using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class AddInterventoAmbToPlanBuilder : ICommandBuilder<AddInterventoAmbToPlan>
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


        public AddInterventoAmbToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public AddInterventoAmbToPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public AddInterventoAmbToPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public AddInterventoAmbToPlanBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public AddInterventoAmbToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddInterventoAmbToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddInterventoAmbToPlan(id,
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