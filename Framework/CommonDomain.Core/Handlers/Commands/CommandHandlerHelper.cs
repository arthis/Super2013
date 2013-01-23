using System;
using System.Collections.Generic;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public  class CommandHandlerHelper
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IActionHandler _actionHandler;
        private readonly ISecurityUserRepository _securityUserRepository;
        private readonly Dictionary<Type, Func<ICommand, CommandValidation>> _dictionnary;

        public CommandHandlerHelper(ICommandRepository commandRepository, IActionHandler actionHandler, ISecurityUserRepository securityUserRepository, Dictionary<Type, Func<ICommand, CommandValidation>> dictionnary)
        {
            
            _commandRepository = commandRepository;
            _actionHandler = actionHandler;
            _securityUserRepository = securityUserRepository;
            _dictionnary = dictionnary;
        }

        public void AddFullyConstrainedCommand<T>(ICommandHandler<T> finalhandler)
            where T : ICommand
        {
            _actionHandler.AddFullyConstrainedActionHandlerFor<T>();
            AddHandler<T>(finalhandler);
        }

        public void AddCommandConstrainedOnlyCommand<T>(ICommandHandler<T> finalhandler)
            where T : ICommand
        {
            _actionHandler.AddCommandContrainedAction<T>();
            AddHandler<T>(finalhandler);
        }

        private void AddHandler<T>(ICommandHandler<T> finalhandler)
            where T : ICommand
        {
            _dictionnary.Add(typeof(T), (cmd) => new SecurityCommandHandler<T>(_actionHandler, _securityUserRepository,
                                                 new ExecuteCommandOnceOnlyHandler<T>(_commandRepository,
                                                 new LogCommandPerfomanceHandler<T>(
                                                       finalhandler)))
                                                .Execute((T)cmd));
        }
    }
}