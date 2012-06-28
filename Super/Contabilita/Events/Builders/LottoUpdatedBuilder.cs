using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Events.Builders
{
    public class LottoUpdatedBuilder : IEventBuilder<LottoUpdated>
    {
        Intervall _intervall;
        private string _description;

        public LottoUpdated Build(Guid id)
        {
            var evt = new LottoUpdated(id, _intervall, _description);
            evt.CommitId = Guid.NewGuid();
            return evt;
        }

        
        public LottoUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public LottoUpdatedBuilder ForIntervall(IntervallBuilder builder)
        {
            _intervall = builder.Build();
            return this;
        }

        public LottoUpdatedBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }
    }

    public static partial class BuildExtensions
    {
        public static LottoUpdatedBuilder ForIntervall(this LottoUpdatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Intervall period)
        {
            var valueBuilder = new IntervallBuilder();
            period.BuildValue(valueBuilder);
            builder.ForIntervall(valueBuilder);
            return builder;
        }
    }
}