using System;
using System.Collections.Generic;
using CommonDomain.Persistence;

namespace CommonDomain.Core
{
    public  class HandlerHelper
    {
        private readonly ICommandRepository _commandRepository;

        public HandlerHelper(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public void Add<T>(Dictionary<Type, Func<ICommand, CommandValidation>> dictionnary, ICommandHandler<T> finalHandler) where T : ICommand
        {
            //to redo something does not go well here...
            dictionnary.Add(typeof(T), (cmd) => new ExecuteCommandOnceOnlyHandler<T>(_commandRepository).Execute((T)cmd, finalHandler));
                    
        }
    }
}