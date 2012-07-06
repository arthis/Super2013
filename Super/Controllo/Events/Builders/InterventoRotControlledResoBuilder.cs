using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Events.Builders
{
    public class InterventoRotControlledResoBuilder : IEventBuilder<InterventoRotControlledReso>
    {
        private Guid _idUtente;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;


        public InterventoRotControlledResoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoRotControlledResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }


        public InterventoRotControlledResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }


        public InterventoRotControlledResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public InterventoRotControlledResoBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public InterventoRotControlledResoBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public InterventoRotControlledResoBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public InterventoRotControlledResoBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public InterventoRotControlledResoBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public InterventoRotControlledResoBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public InterventoRotControlledReso Build(Guid id, long version)
        {
            var cmd = new InterventoRotControlledReso(id, Guid.NewGuid(), version,  _idUtente, _controlDate, _period, _note, _oggetti, _trenoArrivo, _trenoPartenza, _turnoTreno,
                                      _rigaTurnoTreno,
                                      _convoglio);

            

            return cmd;
        }

    }
}