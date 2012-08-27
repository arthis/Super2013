using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.PeriodoProgrammazione;

namespace Super.Contabilita.Events.Builders.PeriodoProgrammazione
{
    public class PeriodoProgrammazioneUpdatedBuilder : IEventBuilder<PeriodoProgrammazioneUpdated>
    {
        private string _description;
        private Interval _interval;


        public PeriodoProgrammazioneUpdated Build(Guid id, long version)
        {
            var evt = new PeriodoProgrammazioneUpdated(id, Guid.NewGuid() ,version,  _interval, _description);
            
            return evt;
        }

        public PeriodoProgrammazioneUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public PeriodoProgrammazioneUpdatedBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

    }


}