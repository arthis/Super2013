using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class AddSchedulazioneRotToPlanBuilder : ICommandBuilder<AddSchedulazioneRotToPlan>
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
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;
        private Period _period;


        public AddSchedulazioneRotToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public AddSchedulazioneRotToPlanBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public AddSchedulazioneRotToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddSchedulazioneRotToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotToPlan(id,
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
                                                 _oggetti,
                                                 _trenoPartenza,
                                                 _trenoArrivo,
                                                 _turnoTreno,
                                                 _rigaTurnoTreno,
                                                 _convoglio);
        }
    }
}