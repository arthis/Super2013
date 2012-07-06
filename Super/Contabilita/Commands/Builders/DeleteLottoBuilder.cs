using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Lotto;

namespace Super.Contabilita.Commands.Builders
{
    public class DeleteLottoBuilder : ICommandBuilder<DeleteLotto>
    {

        public DeleteLotto Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteLotto Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteLotto(id,commitId,version);

            return cmd;
        }


    }
}