using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Impianto;

namespace Super.Contabilita.Events.Builders.Impianto
{
    public class ImpiantoCreatedBuilder : IEventBuilder<ImpiantoCreated>
    {
        Interval _interval;
        private string _description;
        private Guid _idLotto;

        public ImpiantoCreated Build(Guid id, long version)
        {
            var evt = new ImpiantoCreated(id, Guid.NewGuid() ,version,  _interval,_idLotto,  _description);
            
            return evt;
        }

        

        public ImpiantoCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ImpiantoCreatedBuilder ForInterval(IntervalBuilder builder)
        {
            _interval = builder.Build();
            return this;
        }

        public ImpiantoCreatedBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public ImpiantoCreatedBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
            return this;
        }


    }

    public static partial class BuildExtensions
    {
        public static ImpiantoCreatedBuilder ForInterval(this ImpiantoCreatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Interval period)
        {
            var valueBuilder = new IntervalBuilder();
            period.BuildValue(valueBuilder);
            builder.ForInterval(valueBuilder);
            return builder;
        }


    }
}