using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Intervento;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class AddInterventoRotToPlanBuilder : ICommandBuilder<AddInterventoRotToPlan>
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


        public AddInterventoRotToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public AddInterventoRotToPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public AddInterventoRotToPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public AddInterventoRotToPlanBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public AddInterventoRotToPlanBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public AddInterventoRotToPlanBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public AddInterventoRotToPlanBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public AddInterventoRotToPlanBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public AddInterventoRotToPlanBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public AddInterventoRotToPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddInterventoRotToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddInterventoRotToPlan(id,
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
}