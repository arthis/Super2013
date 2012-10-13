using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Plan
{
    public class UpdateSchedulazioneRotOfPlanBuilder : ICommandBuilder<UpdateSchedulazioneRotOfPlan>
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

        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;

        public UpdateSchedulazioneRotOfPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder OfTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForWorkPeriod(WorkPeriod workPeriod)
        {
            _workPeriod = workPeriod;
            return this;
        }

        public UpdateSchedulazioneRotOfPlanBuilder ForPeriod(Period period)
        {
            _period = period;
            return this;
        }


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