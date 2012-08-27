using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Intervento;

namespace Super.Contabilita.Commands.Builders.Intervento
{
    public class CalculateInterventoRotPriceOfPlanBuilder : ICommandBuilder<CalculateInterventoRotPriceOfPlan>
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
        private WorkPeriod _period;
        private string _note;
        private OggettoRot[] _oggetti;
        private Treno _trenoArrivo;
        private Treno _trenoPartenza;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;


        public CalculateInterventoRotPriceOfPlan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CalculateInterventoRotPriceOfPlan Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CalculateInterventoRotPriceOfPlan(id, commitId, version,
                _idPeriodoProgrammazione,
                _idPlan,
                _idCommittente,
                _idLotto,
                _idImpianto,
                _idTipoIntervento,
                _idAppaltatore,
                _idCategoriaCommerciale,
                _idDirezioneRegionale,
                _period,
                _note,
                _oggetti,
                _trenoArrivo,
                _trenoPartenza,
                _turnoTreno,
                _rigaTurnoTreno,
                _convoglio
                );
            return cmd;
        }


        public CalculateInterventoRotPriceOfPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione)
        {
            _idPeriodoProgrammazione = idPeriodoProgrammazione;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForCommittente(Guid idCommittente)
        {
            _idCommittente = idCommittente;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForImpianto(Guid idImpianto)
        {
            _idImpianto = idImpianto;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForTipoIntervento(Guid idTipoIntervento)
        {
            _idTipoIntervento = idTipoIntervento;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForAppaltatore(Guid idAppaltatore)
        {
            _idAppaltatore = idAppaltatore;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale)
        {
            _idCategoriaCommerciale = idCategoriaCommerciale;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale)
        {
            _idDirezioneRegionale = idDirezioneRegionale;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForTrenoArrivo(Treno trenoaArrivo)
        {
            _trenoArrivo = trenoaArrivo;
            return this;
        }
        public CalculateInterventoRotPriceOfPlanBuilder ForTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public CalculateInterventoRotPriceOfPlanBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }
        
       

    }
}
