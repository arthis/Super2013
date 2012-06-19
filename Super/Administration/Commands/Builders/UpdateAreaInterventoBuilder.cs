using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Administration.Commands.AreaIntervento;

namespace Super.Administration.Commands.Builders
{
    public class UpdateAreaInterventoBuilder : ICommandBuilder<UpdateAreaIntervento>
    {
        RollonPeriod _period;
        private string _description;

        public UpdateAreaIntervento Build(Guid id, long version)
        {
            return new UpdateAreaIntervento(id, version, _period, _description);
        }



        public UpdateAreaInterventoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateAreaInterventoBuilder ForPeriod(RollonPeriod period)
        {
            _period = period;
            return this;
        }
    }
}