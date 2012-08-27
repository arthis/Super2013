using System;
using CommonDomain;
using Super.Contabilita.Commands.Committente;

namespace Super.Contabilita.Commands.Builders.Committente
{
    public class DeleteCommittenteBuilder : ICommandBuilder<DeleteCommittente>
    {

        public DeleteCommittente Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteCommittente Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteCommittente(id,commitId,version);

            return cmd;
        }


    }
}