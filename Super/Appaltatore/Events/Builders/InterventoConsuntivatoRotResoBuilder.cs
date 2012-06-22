using System;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Consuntivazione;

namespace Super.Appaltatore.Events.Builders
{

    public class InterventoConsuntivatoRotResoBuilder
    {
        private Guid _id;
        private  string _idInterventoAppaltatore;
        private  DateTime _dataConsuntivazione;
        private  WorkPeriod _period;
        private  string _note;
        private  OggettoRot[] _oggetti;
        private  Treno _trenoPartenza;
        private  Treno _trenoArrivo;
        private  string _turnoTreno;
        private  string _rigaTurnoTreno;
        private  string _convoglio;

        public InterventoConsuntivatoRotResoBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder ForId(Guid id)
        {
            _id = id;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder ForInterventoAppaltatore(string IdInterventoAppaltatore)
        {
            _idInterventoAppaltatore = IdInterventoAppaltatore;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public InterventoConsuntivatoRotResoBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public InterventoConsuntivatoRotReso Build()
        {
            return new InterventoConsuntivatoRotReso(_id, _idInterventoAppaltatore, _dataConsuntivazione, _period, _note,
                 _oggetti, _trenoPartenza, _trenoArrivo, _turnoTreno, _rigaTurnoTreno, _convoglio);
        }

    }
}
