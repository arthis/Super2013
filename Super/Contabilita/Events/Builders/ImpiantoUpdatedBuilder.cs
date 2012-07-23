using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Impianto;

namespace Super.Contabilita.Events.Builders
{
    public class ImpiantoUpdatedBuilder : IEventBuilder<ImpiantoUpdated>
    {
        Interval _interval;
        private string _description;

        public ImpiantoUpdated Build(Guid id, long version)
        {
            var evt = new ImpiantoUpdated(id, Guid.NewGuid() ,version, _interval, _description);
            
            return evt;
        }

        
        public ImpiantoUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ImpiantoUpdatedBuilder ForInterval(IntervalBuilder builder)
        {
            _interval = builder.Build();
            return this;
        }

        public ImpiantoUpdatedBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }
    }

    public static partial class BuildExtensions
    {
        public static ImpiantoUpdatedBuilder ForInterval(this ImpiantoUpdatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Interval period)
        {
            var valueBuilder = new IntervalBuilder();
            period.BuildValue(valueBuilder);
            builder.ForInterval(valueBuilder);
            return builder;
        }
    }
}