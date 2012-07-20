using System;
using CommonDomain;

namespace Super.Controllo.Events.Builders
{
    public class InterventoClosedBuilder : IEventBuilder<InterventoClosed>
    {
        private Guid _idUser;
        private DateTime _closingDate;

        public InterventoClosedBuilder By(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

        public InterventoClosedBuilder When(DateTime closingDate)
        {
            _closingDate = closingDate;
            return this;
        }

        public InterventoClosed Build(Guid id, long version)
        {
            var cmd = new InterventoClosed(id, Guid.NewGuid(), version,  _idUser, _closingDate);

            

            return cmd;
        }

    }
}