using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class UpdateSchedulazioneRotManOfPlanBuilder : ICommandBuilder<UpdateSchedulazioneRotManOfPlan>
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

        private OggettoRotMan[] _oggetti;

        public UpdateSchedulazioneRotManOfPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlanBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }


        public UpdateSchedulazioneRotManOfPlanBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public UpdateSchedulazioneRotManOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateSchedulazioneRotManOfPlan Build(Guid id, Guid commitId, long version)
        {
            return new UpdateSchedulazioneRotManOfPlan(id,
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