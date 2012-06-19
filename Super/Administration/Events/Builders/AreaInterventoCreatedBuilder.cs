using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.Events.Builders;

namespace Super.Administration.Events.Builders
{
    public class AreaInterventoCreatedBuilder : IEventBuilder<AreaInterventoCreated>
    {
        RollonPeriod _period;
        private DateTime _creationDate;
        private string _description;

        public AreaInterventoCreated Build(Guid id, long version)
        {
            return new AreaInterventoCreated(id, version, _period, _creationDate, _description);
        }

        public AreaInterventoCreatedBuilder ForCreationDate(DateTime creationDate)
        {
            _creationDate = creationDate;
            return this;
        }

        public AreaInterventoCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public AreaInterventoCreatedBuilder ForPeriod(RollonPeriodBuilder builder)
        {
            _period = builder.Build();
            return this;
        }
    }

    public  static partial class BuildExtensions
    {
        public static AreaInterventoCreatedBuilder ForPeriod(this AreaInterventoCreatedBuilder builder, CommonDomain.Core.Super.Domain.ValueObjects.RollonPeriod period)
        {
            var valueBuilder = new RollonPeriodBuilder();
            period.BuildValue(valueBuilder);
            builder.ForPeriod(valueBuilder);
            return builder;
        }

       
    }

}
