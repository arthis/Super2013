using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Appaltatore.Commands.Builders
{

    public class ConsuntivareRotResoBuilder : ICommandBuilder<ConsuntivareRotReso>
    {
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

        public ConsuntivareRotResoBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public ConsuntivareRotResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public ConsuntivareRotResoBuilder ForInterventoAppaltatore(string IdInterventoAppaltatore)
        {
            _idInterventoAppaltatore = IdInterventoAppaltatore;
            return this;
        }

        public ConsuntivareRotResoBuilder When(DateTime dataConsuntivazione)
        {
            _dataConsuntivazione = dataConsuntivazione;
            return this;
        }

        public ConsuntivareRotResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        public ConsuntivareRotResoBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public ConsuntivareRotResoBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public ConsuntivareRotResoBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public ConsuntivareRotResoBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public ConsuntivareRotResoBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public ConsuntivareRotReso Build(Guid id)
        {
            var cmd = new  ConsuntivareRotReso(id, _idInterventoAppaltatore, _dataConsuntivazione, _period, _note,
                 _oggetti, _trenoPartenza, _trenoArrivo, _turnoTreno, _rigaTurnoTreno, _convoglio);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}
