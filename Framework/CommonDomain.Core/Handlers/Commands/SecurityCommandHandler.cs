using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    

    
    public class SecurityCommandHandler<T,TSession> : ICommandHandler<T> where T : ICommand where  TSession:ISession
    {
        
        private readonly ISessionFactory<TSession> _sessionFactory;
        private ICommandHandler<T> _next;

        public SecurityCommandHandler(ISessionFactory<TSession> sessionFactory, ICommandHandler<T> next)
        {
            Contract.Requires(sessionFactory != null);
            Contract.Requires(next != null);    

            _sessionFactory = sessionFactory;
            _next = next;
        }

        public CommandValidation Execute(T command)
        {
            //inject session dependency into finalhandler

            var session = _sessionFactory.CreateSession(command);

            if (session.IsAuthenticated)
            {
                var validation = _next.Execute(command);

                return validation;
            }
            else
            {
                throw new SecurityException("user not authenticated");
            }
        }
    }
}