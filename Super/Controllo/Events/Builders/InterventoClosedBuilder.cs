using System;
using CommonDomain;

namespace Super.Controllo.Events.Builders
{
    public class InterventoClosedBuilder : IEventBuilder<InterventoClosed>
    {
        private Guid _idUtente;
        private DateTime _closingDate;

        public InterventoClosedBuilder By(Guid idUtente)
        {
            _idUtente = idUtente;
            return this;
        }

        public InterventoClosedBuilder When(DateTime closingDate)
        {
            _closingDate = closingDate;
            return this;
        }

        public InterventoClosed Build(Guid id, long version)
        {
            var cmd = new InterventoClosed(id, Guid.NewGuid(), version,  _idUtente, _closingDate);

            

            return cmd;
        }

    }
}