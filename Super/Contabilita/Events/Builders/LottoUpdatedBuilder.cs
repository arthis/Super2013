using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Events.Builders
{
    public class LottoUpdatedBuilder : IEventBuilder<LottoUpdated>
    {
        Interval _interval;
        private string _description;

        public LottoUpdated Build(Guid id, long version)
        {
            var evt = new LottoUpdated(id, Guid.NewGuid() ,version, _interval, _description);
            
            return evt;
        }

        
        public LottoUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public LottoUpdatedBuilder ForInterval(IntervalBuilder builder)
        {
            _interval = builder.Build();
            return this;
        }

        public LottoUpdatedBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }
    }

    public static partial class BuildExtensions
    {
        public static LottoUpdatedBuilder ForInterval(this LottoUpdatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Interval period)
        {
            var valueBuilder = new IntervalBuilder();
            period.BuildValue(valueBuilder);
            builder.ForInterval(valueBuilder);
            return builder;
        }
    }
}