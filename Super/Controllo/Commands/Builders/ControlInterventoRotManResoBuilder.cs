using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Controllo.Commands.Builders
{
    public class ControlInterventoRotManResoBuilder : ICommandBuilder<ControlInterventoRotManReso>
    {
        private Guid _idUtente;
        private DateTime _controlDate;
        private string _note;
        private WorkPeriod _period;
        private OggettoRotMan[] _oggetti;
        

        public ControlInterventoRotManResoBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public ControlInterventoRotManResoBuilder When(DateTime controlDate)
        {
            _controlDate = controlDate;
            return this;
        }


        public ControlInterventoRotManResoBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }


        public ControlInterventoRotManResoBuilder ForPeriod(WorkPeriod period)
        {
            _period = period;
            return this;
        }

        public ControlInterventoRotManResoBuilder WithOggetti(OggettoRotMan[] oggetti)
        {
            _oggetti = oggetti;
            return this;
        }



        public ControlInterventoRotManReso Build(Guid id)
        {
            var cmd = new ControlInterventoRotManReso(id, _idUtente, _controlDate, _period, _note, _oggetti);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}