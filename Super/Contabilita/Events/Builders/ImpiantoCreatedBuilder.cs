using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Impianto;

namespace Super.Contabilita.Events.Builders
{
    public class ImpiantoCreatedBuilder : IEventBuilder<ImpiantoCreated>
    {
        Intervall _intervall;
        private DateTime _creationDate;
        private string _description;
        private Guid _idLotto;

        public ImpiantoCreated Build(Guid id)
        {
            var evt = new ImpiantoCreated(id,  _intervall,_idLotto, _creationDate, _description);
            evt.CommitId = Guid.NewGuid();
            return evt;
        }

        public ImpiantoCreatedBuilder ForCreationDate(DateTime creationDate)
        {
            _creationDate = creationDate;
            return this;
        }

        public ImpiantoCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public ImpiantoCreatedBuilder ForIntervall(IntervallBuilder builder)
        {
            _intervall = builder.Build();
            return this;
        }

        public ImpiantoCreatedBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
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
        public static ImpiantoCreatedBuilder ForIntervall(this ImpiantoCreatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.Intervall period)
        {
            var valueBuilder = new IntervallBuilder();
            period.BuildValue(valueBuilder);
            builder.ForIntervall(valueBuilder);
            return builder;
        }


    }
}