using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Impianto;

namespace Super.Contabilita.Events.Builders
{
    public class ImpiantoUpdatedBuilder : IEventBuilder<ImpiantoUpdated>
    {
        Intervall _intervall;
        private string _description;

        public ImpiantoUpdated Build(Guid id)
        {
            return new ImpiantoUpdated(id, _intervall, _description);
        }

        
        public ImpiantoUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ImpiantoUpdatedBuilder ForIntervall(IntervallBuilder builder)
        {
            _intervall = builder.Build();
            return this;
        }

        public ImpiantoUpdatedBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }
    }

    public static partial class BuildExtensions
    {
        public static ImpiantoUpdatedBuilder ForIntervall(this ImpiantoUpdatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Intervall period)
        {
            var valueBuilder = new IntervallBuilder();
            period.BuildValue(valueBuilder);
            builder.ForIntervall(valueBuilder);
            return builder;
        }
    }
}