using CommonDomain.Persistence;

namespace CommonDomain.Core
{
    public class ExecuteCommandOnceOnlyHandler<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandRepository _commandRepository;

        public ExecuteCommandOnceOnlyHandler(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public CommandValidation Execute(T command, ICommandHandler<T> next)
        {
            //check that the commitid is not part of the eventstore already
            var isExecuted = _commandRepository.IsExecuted(command.CommitId);

            if (isExecuted)
            {
                var msg = string.Format("The command '{0}' was already processed", command.CommitId);
                throw new CommandAlreadyProcessedException(msg);
            }

            _commandRepository.Save(command);

            var validation = next.Execute(command, next);

            _commandRepository.SaveAsExecuted(command);

            return validation;
        }
    }
}