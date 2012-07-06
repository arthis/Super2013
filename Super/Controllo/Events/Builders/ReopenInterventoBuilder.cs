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

        public InterventoReopened Build(Guid id, long version)
        {
            var cmd = new InterventoReopened(id, Guid.NewGuid(), version,  _idUtente, _reopeningDate);

            

            return cmd;
        }

    }
}