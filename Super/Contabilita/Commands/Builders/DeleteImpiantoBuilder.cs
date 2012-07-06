using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Impianto;

namespace Super.Contabilita.Commands.Builders
{
    public class DeleteImpiantoBuilder : ICommandBuilder<DeleteImpianto>
    {

        public DeleteImpianto Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteImpianto Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteImpianto(id,commitId,version);

            return cmd;
        }


    }
}