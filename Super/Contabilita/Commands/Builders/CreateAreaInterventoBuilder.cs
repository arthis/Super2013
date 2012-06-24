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
        private Guid _idLotto;

        public CreateAreaIntervento Build(Guid id)
        {
            return new CreateAreaIntervento(id, _period, _creationDate, _description, _idLotto);
        }

        public CreateAreaInterventoBuilder ForCreationDate(DateTime creationDate)
        {
            _creationDate = creationDate;
            return this;
        }

        public CreateAreaInterventoBuilder ForLotto(Guid idLotto)
        {
            _idLotto = idLotto;
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
