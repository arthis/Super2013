using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.Builders
{
    public class UpdateLottoBuilder : ICommandBuilder<UpdateLotto>
    {
        Intervall _intervall;
        private string _description;

        public UpdateLotto Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateLotto Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateLotto(id, commitId, version, _intervall, _description);

            return cmd;
        }



        public UpdateLottoBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        public UpdateLottoBuilder ForIntervall(Intervall intervall)
        {
            _intervall = intervall;
            return this;
        }

    
    }
}