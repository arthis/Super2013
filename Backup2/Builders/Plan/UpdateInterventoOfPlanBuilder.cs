using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class UpdateInterventoOfPlanBuilder
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

        public UpdateInterventoOfPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public UpdateInterventoOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public UpdateInterventoOfPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public UpdateInterventoOfPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public UpdateInterventoOfPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public UpdateInterventoOfPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public UpdateInterventoOfPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public UpdateInterventoOfPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public UpdateInterventoOfPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public UpdateInterventoOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public UpdateInterventoOfPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

    }

    public class UpdateInterventoRotOfPlanBuilder : UpdateInterventoOfPlanBuilder,
                                                   ICommandBuilder<UpdateInterventoRotOfPlan>
    {
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;

        public UpdateInterventoRotOfPlanBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public UpdateInterventoRotOfPlanBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public UpdateInterventoRotOfPlanBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public UpdateInterventoRotOfPlanBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public UpdateInterventoRotOfPlanBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public UpdateInterventoRotOfPlanBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public UpdateInterventoRotOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateInterventoRotOfPlan Build(Guid id, Guid commitId, long version)
        {
            return new UpdateInterventoRotOfPlan(id,
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

    public class UpdateInterventoRotManOfPlanBuilder : UpdateInterventoOfPlanBuilder,
                                                   ICommandBuilder<UpdateInterventoRotManOfPlan>
    {
        private OggettoRotMan[] _oggetti;

        public UpdateInterventoRotManOfPlanBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public UpdateInterventoRotManOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateInterventoRotManOfPlan Build(Guid id, Guid commitId, long version)
        {
            return new UpdateInterventoRotManOfPlan(id,
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

    public class UpdateInterventoAmbOfPlanBuilder : UpdateInterventoOfPlanBuilder,
                                                   ICommandBuilder<UpdateInterventoAmbOfPlan>
    {
        private int _quantity;
        private string _description;


        public UpdateInterventoAmbOfPlanBuilder ForQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public UpdateInterventoAmbOfPlanBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateInterventoAmbOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateInterventoAmbOfPlan Build(Guid id, Guid commitId, long version)
        {
            return new UpdateInterventoAmbOfPlan(id,
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