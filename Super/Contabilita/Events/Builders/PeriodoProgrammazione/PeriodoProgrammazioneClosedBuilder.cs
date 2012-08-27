using System;
using CommonDomain;
using Super.Contabilita.Events.PeriodoProgrammazione;

namespace Super.Contabilita.Events.Builders.PeriodoProgrammazione
{
    public class PeriodoProgrammazioneClosedBuilder : IEventBuilder<PeriodoProgrammazioneClosed>
    {
        private DateTime _closingDate;
        private Guid _idUser;


        public PeriodoProgrammazioneClosed Build(Guid id, long version)
        {
            var evt = new PeriodoProgrammazioneClosed(id, Guid.NewGuid(), version,_closingDate, _idUser);
            return evt;
        }


        public PeriodoProgrammazioneClosedBuilder When(DateTime closingDate)
        {
            _closingDate = closingDate;
            return this;
        }

        public PeriodoProgrammazioneClosedBuilder By(Guid idUser)
        {
            _idUser = idUser;
            return this;
        }

    }
}