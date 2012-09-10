using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class AddSchedulazioneRotManToPlanBuilder : ICommandBuilder<AddSchedulazioneRotManToPlan>
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


        public AddSchedulazioneRotManToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public AddSchedulazioneRotManToPlanBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public AddSchedulazioneRotManToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddSchedulazioneRotManToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotManToPlan(id,
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