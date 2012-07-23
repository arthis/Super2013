using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.Builders
{
    public class CreateLottoBuilder : ICommandBuilder<CreateLotto>
    {
        Interval _interval;
        private DateTime _creationDate;
        private string _description;

        public CreateLotto Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateLotto Build(Guid id, Guid commitId, long version)
        {
             var cmd = new CreateLotto(id, commitId, version, _interval, _creationDate, _description);

            return cmd;
        }

        public CreateLottoBuilder ForCreationDate(DateTime creationDate)
        {
            _creationDate = creationDate;
            return this;
        }


        public CreateLottoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreateLottoBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }
    }
}