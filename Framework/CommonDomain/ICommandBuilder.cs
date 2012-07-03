using System;

namespace CommonDomain
{
    public interface ICommandBuilder<TCommand> where TCommand : IMessage
    {
        TCommand Build(Guid id,  long version);
        TCommand Build(Guid id, Guid commitId, long version);
    }
}