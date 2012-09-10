using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class UpdateSchedulazioneOfPlanBuilder
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

        public UpdateSchedulazioneOfPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public UpdateSchedulazioneOfPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

    }

    public class UpdateSchedulazioneRotOfPlanBuilder : UpdateSchedulazioneOfPlanBuilder,
                                                   ICommandBuilder<UpdateSchedulazioneRotOfPlan>
    {
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;

        public UpdateSchedulazioneRotOfPlanBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public UpdateSchedulazioneRotOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateSchedulazioneRotOfPlan Build(Guid id, Guid commitId, long version)
        {
            return new UpdateSchedulazioneRotOfPlan(id,
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
                                                _oggetti,
                                                _trenoPartenza,
                                                _trenoArrivo,
                                                _turnoTreno,
                                                _rigaTurnoTreno,
                                                _convoglio);
        }
    }

    public class UpdateSchedulazioneRotManOfPlanBuilder : UpdateSchedulazioneOfPlanBuilder,
                                                   ICommandBuilder<UpdateSchedulazioneRotManOfPlan>
    {
        private OggettoRotMan[] _oggetti;

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
                                                _note,
                                                _oggetti);
        }
    }

    public class UpdateSchedulazioneAmbOfPlanBuilder : UpdateSchedulazioneOfPlanBuilder,
                                                   ICommandBuilder<UpdateSchedulazioneAmbOfPlan>
    {
        private int _quantity;
        private string _description;


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
                                                _note,
                                                _quantity,
                                                _description);
        }
    }
}