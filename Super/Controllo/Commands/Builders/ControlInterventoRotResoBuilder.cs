using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Commands.Builders
{
    public class ControlInterventoRotResoBuilder: ICommandBuilder< ControlInterventoRotReso>
    {
        private Guid _idUser;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private OggettoRot[] _oggetti;
        private Treno _trenoPartenza;
        private Treno _trenoArrivo;
        private string _turnoTreno;
        private string _rigaTurnoTreno;
        private string _convoglio;


        public ControlInterventoRotResoBuilder By(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public ControlInterventoRotResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }


        public ControlInterventoRotResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }


        public ControlInterventoRotResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public ControlInterventoRotResoBuilder WithOggetti(OggettoRot[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }

        public ControlInterventoRotResoBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            _trenoArrivo = trenoArrivo;
            return this;
        }

        public ControlInterventoRotResoBuilder WithTrenoPartenza(Treno trenoPartenza)
        {
            _trenoPartenza = trenoPartenza;
            return this;
        }

        public ControlInterventoRotResoBuilder WithTurnoTreno(string turnoTreno)
        {
            _turnoTreno = turnoTreno;
            return this;
        }

        public ControlInterventoRotResoBuilder WithRigaTurnoTreno(string rigaTurnoTreno)
        {
            _rigaTurnoTreno = rigaTurnoTreno;
            return this;
        }

        public ControlInterventoRotResoBuilder ForConvoglio(string convoglio)
        {
            _convoglio = convoglio;
            return this;
        }

        public ControlInterventoRotReso Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public ControlInterventoRotReso Build(Guid id, Guid commitId, long version)
        {
            var cmd = new ControlInterventoRotReso(id, commitId, version, _idUser, _controlDate, _period, _note, _oggetti, _trenoArrivo, _trenoPartenza, _turnoTreno,
                                      _rigaTurnoTreno,
                                      _convoglio);

            

            return cmd;
        }

    }
}