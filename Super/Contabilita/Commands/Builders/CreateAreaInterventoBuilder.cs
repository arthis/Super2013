using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.AreaIntervento;

namespace Super.Contabilita.Commands.Builders
{
    public class CreateAreaInterventoBuilder : ICommandBuilder<CreateAreaIntervento>
    {
        Intervall _period;
        private DateTime _creationDate;
        private string _description;

        public CreateAreaIntervento Build(Guid id, long version)
        {
            return new CreateAreaIntervento(id, version, _period, _creationDate, _description);
        }

        public CreateAreaInterventoBuilder ForCreationDate(DateTime creationDate)
        {
            _creationDate = creationDate;
            return this;
        }

        public CreateAreaInterventoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateAreaInterventoBuilder ForPeriod(Intervall period)
        {
            _period = period;
            return this;
        }
    }
}
