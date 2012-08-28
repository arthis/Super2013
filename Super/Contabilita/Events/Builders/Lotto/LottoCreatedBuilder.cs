using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Events.Builders.Lotto
{
    public class LottoCreatedBuilder : IEventBuilder<LottoCreated>
    {
        Interval _interval;
        private string _description;
        

        public LottoCreated Build(Guid id, long version)
        {
            var evt = new LottoCreated(id, Guid.NewGuid() ,version,  _interval,  _description);
            
            return evt;
        }

        

        public LottoCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public LottoCreatedBuilder ForInterval(IntervalBuilder builder)
        {
            _interval = builder.Build();
            return this;
        }

        public LottoCreatedBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        
    }

    public static partial class BuildExtensions
    {
        public static LottoCreatedBuilder ForInterval(this LottoCreatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Interval period)
        {
            var valueBuilder = new IntervalBuilder();
            period.BuildValue(valueBuilder);
            builder.ForInterval(valueBuilder);
            return builder;
        }


    }
}