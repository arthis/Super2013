using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Intervento;

namespace Super.Programmazione.Events.Builders.Intervento
{
    public class InterventoRotManUpdatedOfPlanBuilder : IEventBuilder<InterventoRotManUpdatedOfPlan>
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
        private OggettoRotMan[] _oggetti;

        public InterventoRotManUpdatedOfPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public InterventoRotManUpdatedOfPlanBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoRotManUpdatedOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public InterventoRotManUpdatedOfPlan Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotManUpdatedOfPlan(id,
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
                                                     _oggetti);
        }
    }
}