using System;

namespace CommonDomain
{
    public interface ICommandBuilder<TCommand> where TCommand : IMessage
    {
        TCommand Build(Guid id);
    }
}