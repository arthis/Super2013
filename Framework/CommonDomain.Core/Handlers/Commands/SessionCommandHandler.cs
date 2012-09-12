using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public class SessionCommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ISessionRepository _sessionRepository;
        private IFinalHandler<T> _next;

        public SessionCommandHandler(ISessionRepository sessionrepository, IFinalHandler<T> next)
        {
            Contract.Requires(sessionrepository!=null);
            Contract.Requires(next != null);    

            _sessionRepository = sessionrepository;
            _next = next;
        }

        public CommandValidation Execute(T command)
        {
            //inject session dependency into finalhandler
            _next.Session = _sessionRepository.GetSession(command.SecurityToken);
            
            if(_next.Session==null)
                throw  new Exception("no available session found to execute this command");

            var validation = _next.Execute(command);

            return validation;
        }
    }
}