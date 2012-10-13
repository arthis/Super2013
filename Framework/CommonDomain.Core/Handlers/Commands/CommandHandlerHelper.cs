using System;
using System.Collections.Generic;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public  class CommandHandlerHelper<TSession> where TSession :ISession
    {
        private readonly ICommandRepository _commandRepository;
        private readonly ISessionFactory<TSession> _sessionFactory;
        private readonly Dictionary<Type, Func<ICommand, CommandValidation>> _dictionnary;

        public CommandHandlerHelper(ICommandRepository commandRepository, ISessionFactory<TSession> sessionFactory, Dictionary<Type, Func<ICommand, CommandValidation>> dictionnary)
        {
            
            _commandRepository = commandRepository;
            _sessionFactory = sessionFactory;
            _dictionnary = dictionnary;
        }

        public void Add<T>(ICommandHandler<T> finalhandler) where T : ICommand
        {
            _dictionnary.Add(typeof(T), (cmd) => new SecurityCommandHandler<T,TSession>(_sessionFactory,
                                                new ExecuteCommandOnceOnlyHandler<T>(_commandRepository,
                                                new LogCommandPerfomanceHandler<T>(
                                                finalhandler)))
                                                .Execute((T)cmd));
        }
    }
}