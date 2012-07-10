using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers
{
    public class ExecuteCommandOnceOnlyHandler<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandRepository _commandRepository;
        private ICommandHandler<T> _next;

        public ExecuteCommandOnceOnlyHandler(ICommandRepository commandRepository, ICommandHandler<T> next)
        {
            Contract.Requires(commandRepository!=null);
            Contract.Requires(next != null);    

            _commandRepository = commandRepository;
            _next = next;
        }

        public CommandValidation Execute(T command)
        {
            //check that the commitid is not part of the eventstore already
            var isExecuted = _commandRepository.IsExecuted(command.CommitId);

            if (isExecuted)
            {
                var msg = string.Format("The command '{0}' was already processed", command.CommitId);
                throw new CommandAlreadyProcessedException(msg);
            }

            _commandRepository.Save(command);

            var validation = _next.Execute(command);

            _commandRepository.SaveAsExecuted(command);

            return validation;
        }
    }
}