using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Events.Builders
{
    public class LottoCreatedBuilder : IEventBuilder<LottoCreated>
    {
        Intervall _intervall;
        private DateTime _creationDate;
        private string _description;
        

        public LottoCreated Build(Guid id)
        {
            return new LottoCreated(id,  _intervall, _creationDate, _description);
        }

        public LottoCreatedBuilder ForCreationDate(DateTime creationDate)
        {
            _creationDate = creationDate;
            return this;
        }

        public LottoCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public LottoCreatedBuilder ForIntervall(IntervallBuilder builder)
        {
            _intervall = builder.Build();
            return this;
        }

        public LottoCreatedBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }

        
    }

    public static partial class BuildExtensions
    {
        public static LottoCreatedBuilder ForIntervall(this LottoCreatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Intervall period)
        {
            var valueBuilder = new IntervallBuilder();
            period.BuildValue(valueBuilder);
            builder.ForIntervall(valueBuilder);
            return builder;
        }


    }
}