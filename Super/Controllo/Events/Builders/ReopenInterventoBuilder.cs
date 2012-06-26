using System;
using CommonDomain;

namespace Super.Controllo.Events.Builders
{
    public class InterventoReopenedBuilder : IEventBuilder<InterventoReopened>
    {
        private Guid _idUtente;
        private DateTime _reopeningDate;

        public InterventoReopenedBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoReopenedBuilder When(DateTime reopeningDate)
        {
            _reopeningDate = reopeningDate;
            return this;
        }

        public InterventoReopened Build(Guid id)
        {
            var cmd = new InterventoReopened(id, _idUtente, _reopeningDate);

            cmd.CommitId = Guid.NewGuid();

            return cmd;
        }

    }
}