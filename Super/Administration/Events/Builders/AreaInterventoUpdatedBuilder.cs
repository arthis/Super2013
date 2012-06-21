using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Administration.Events.AreaIntervento;

namespace Super.Administration.Events.Builders
{
    public class AreaInterventoUpdatedBuilder : IEventBuilder<AreaInterventoUpdated>
    {
        Intervall _period;
        private string _description;

        public AreaInterventoUpdated Build(Guid id, long version)
        {
            return new AreaInterventoUpdated(id, version, _period, _description);
        }

        
        public AreaInterventoUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public AreaInterventoUpdatedBuilder ForPeriod(IntervallBuilder builder)
        {
            _period = builder.Build();
            return this;
        }
    }

    public static partial class BuildExtensions
    {
        public static AreaInterventoUpdatedBuilder ForPeriod(this AreaInterventoUpdatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Intervall period)
        {
            var valueBuilder = new IntervallBuilder();
            period.BuildValue(valueBuilder);
            builder.ForPeriod(valueBuilder);
            return builder;
        }
    }
}