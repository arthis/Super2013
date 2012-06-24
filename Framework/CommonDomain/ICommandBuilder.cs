using System;

namespace CommonDomain
{
    public interface ICommandBuilder<TCommand> where TCommand : ICommand
    {
        TCommand Build(Guid id);
    }
}