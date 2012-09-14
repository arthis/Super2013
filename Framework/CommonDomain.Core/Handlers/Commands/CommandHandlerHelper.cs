using System;
using System.Collections.Generic;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public  class CommandHandlerHelper
    {
        private readonly ICommandRepository _commandRepository;
        private readonly ISessionFactory _sessionFactory;
        private readonly Dictionary<Type, Func<ICommand, CommandValidation>> _dictionnary;

        public CommandHandlerHelper(ICommandRepository commandRepository, ISessionFactory sessionFactory, Dictionary<Type, Func<ICommand, CommandValidation>> dictionnary)
        {
            _commandRepository = commandRepository;
            _sessionFactory = sessionFactory;
            _dictionnary = dictionnary;
        }

        public void Add<T>(ICommandHandler<T> finalhandler) where T : ICommand
        {
            _dictionnary.Add(typeof(T), (cmd) => new SecurityCommandHandler<T>(_sessionFactory,
                                                new ExecuteCommandOnceOnlyHandler<T>(_commandRepository,
                                                new LogCommandPerfomanceHandler<T>(
                                                finalhandler)))
                                                .Execute((T)cmd));
        }
    }

    public class PortHandlerHelper
    {

        public void Add<TEvent,TCommand>(Dictionary<Type, Func<IEvent,ICommand>> dictionnary,IPortHandler<TEvent,TCommand> eventHandler) 
            where TEvent  : IEvent
            where TCommand  : ICommand
        {
            dictionnary.Add(typeof(TEvent), (evt)=> eventHandler.Port((TEvent)evt) );
        }
    }
}