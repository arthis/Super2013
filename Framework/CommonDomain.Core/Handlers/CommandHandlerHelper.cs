using System;
using System.Collections.Generic;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers
{
    public  class CommandHandlerHelper
    {
        private readonly ICommandRepository _commandRepository;

        public CommandHandlerHelper(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public void Add<T>(Dictionary<Type, Func<ICommand, CommandValidation>> dictionnary, ICommandHandler<T> finalhandler) where T : ICommand
        {
            //to redo something does not go well here...
            dictionnary.Add(typeof(T), (cmd) => new ExecuteCommandOnceOnlyHandler<T>(_commandRepository,
                                                     new LogCommandPerfomanceHandler<T>(finalhandler))
                                                        .Execute((T)cmd));
                    
        }
    }
}