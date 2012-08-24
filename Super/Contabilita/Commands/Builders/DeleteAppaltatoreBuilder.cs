using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Appaltatore;

namespace Super.Contabilita.Commands.Builders
{
    public class DeleteAppaltatoreBuilder : ICommandBuilder<DeleteAppaltatore>
    {

        public DeleteAppaltatore Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteAppaltatore Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteAppaltatore(id,commitId,version);

            return cmd;
        }


    }
}