using System;
using System.Collections.Generic;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public  class CommandHandlerHelper
    {
        private readonly ICommandRepository _commandRepository;
        private readonly ISessionFactory _sessionFactory;

        public CommandHandlerHelper(ICommandRepository commandRepository,ISessionFactory sessionFactory)
        {
            _commandRepository = commandRepository;
            _sessionFactory = sessionFactory;
        }

        public void Add<T>(Dictionary<Type, Func<ICommand, CommandValidation>> dictionnary, ICommandHandler<T> finalhandler) where T : ICommand
        {
            dictionnary.Add(typeof(T), (cmd) => new SecurityCommandHandler<T>(_sessionFactory,
                                                new ExecuteCommandOnceOnlyHandler<T>(_commandRepository,
                                                new LogCommandPerfomanceHandler<T>(
                                                finalhandler)))
                                                .Execute((T)cmd));
        }
    }

    public class PortHandlerHelper
    {

        public void Add<T>(Dictionary<Type, Action<IEvent>> dictionnary,IPortHandler<T> eventHandler) where T : IEvent
        {
            dictionnary.Add(typeof(T), (evt) => eventHandler.port((T)evt) );
        }
    }
}