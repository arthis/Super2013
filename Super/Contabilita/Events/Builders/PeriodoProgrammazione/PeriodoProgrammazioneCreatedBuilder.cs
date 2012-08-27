using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.PeriodoProgrammazione;

namespace Super.Contabilita.Events.Builders.PeriodoProgrammazione
{
    public class PeriodoProgrammazioneCreatedBuilder : IEventBuilder<PeriodoProgrammazioneCreated>
    {
        private string _description;
        private Interval _interval;


        public PeriodoProgrammazioneCreated Build(Guid id, long version)
        {
            var evt = new PeriodoProgrammazioneCreated(id, Guid.NewGuid() ,version, _interval, _description);
            return evt;
        }


        public PeriodoProgrammazioneCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public PeriodoProgrammazioneCreatedBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

    }

}