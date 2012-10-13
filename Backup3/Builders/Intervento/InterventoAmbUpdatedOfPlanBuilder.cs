using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Intervento;

namespace Super.Programmazione.Events.Builders.Intervento
{
    public class InterventoAmbUpdatedOfPlanBuilder : IEventBuilder<InterventoAmbUpdatedOfPlan>
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

        public InterventoAmbUpdatedOfPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }


        public InterventoAmbUpdatedOfPlanBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public InterventoAmbUpdatedOfPlanBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public InterventoAmbUpdatedOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public InterventoAmbUpdatedOfPlan Build(Guid id, Guid commitId, long version)
        {
            return new InterventoAmbUpdatedOfPlan(id,
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