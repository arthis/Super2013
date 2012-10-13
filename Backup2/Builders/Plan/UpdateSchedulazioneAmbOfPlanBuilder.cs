using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class UpdateSchedulazioneAmbOfPlanBuilder : ICommandBuilder<UpdateSchedulazioneAmbOfPlan>
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
        private Period _period;

        private int _quantity;
        private string _description;

        public UpdateSchedulazioneAmbOfPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlanBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateSchedulazioneAmbOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateSchedulazioneAmbOfPlan Build(Guid id, Guid commitId, long version)
        {
            return new UpdateSchedulazioneAmbOfPlan(id,
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