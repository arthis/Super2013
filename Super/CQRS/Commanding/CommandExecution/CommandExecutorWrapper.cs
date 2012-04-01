using System;

namespace Cqrs.Commanding.CommandExecution
{
    public class CommandExecutorWrapper<TCommand> : ICommandExecutor<TCommand> where TCommand:ICommand
    {
        private readonly Action<TCommand> _action;

        public CommandExecutorWrapper(Action<TCommand> action)
        {
            if(action == null) throw new ArgumentNullException("action");

            _action = action;
        }

        public void Execute(TCommand command)
        {
            _action(command);
        }
    }
}