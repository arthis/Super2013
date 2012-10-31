using System;
using System.Collections.Generic;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public  class CommandHandlerHelper
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IActionFactory _actionFactory;
        private readonly ISecurityUserRepository _securityUserRepository;
        private readonly Dictionary<Type, Func<ICommand, CommandValidation>> _dictionnary;

        public CommandHandlerHelper(ICommandRepository commandRepository, IActionFactory actionFactory, ISecurityUserRepository securityUserRepository, Dictionary<Type, Func<ICommand, CommandValidation>> dictionnary)
        {
            
            _commandRepository = commandRepository;
            _actionFactory = actionFactory;
            _securityUserRepository = securityUserRepository;
            _dictionnary = dictionnary;
        }

        public void Add<T>(ICommandHandler<T> finalhandler)
            where T : ICommand
        {
            _dictionnary.Add(typeof(T), (cmd) => new SecurityCommandHandler<T>(_actionFactory,_securityUserRepository,
                                                 new ExecuteCommandOnceOnlyHandler<T>(_commandRepository,
                                                 new LogCommandPerfomanceHandler<T>(
                                                       finalhandler)))
                                                .Execute((T)cmd));
        }
    }
}