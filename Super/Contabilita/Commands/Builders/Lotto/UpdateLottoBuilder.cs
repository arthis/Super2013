using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.Builders.Lotto
{
    public class UpdateLottoBuilder : ICommandBuilder<UpdateLotto>
    {
        Interval _interval;
        private string _description;

        public UpdateLotto Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateLotto Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateLotto(id, commitId, version, _interval, _description);

            return cmd;
        }



        public UpdateLottoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateLottoBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

    
    }
}