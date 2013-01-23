using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{



    public class SecurityCommandHandler<T> : ICommandHandler<T> where T : ICommand  
    {

        private readonly IActionHandler _actionHandler;
        private ICommandHandler<T> _next;
        private readonly ISecurityUserRepository _repositorySecurityUser;

        public SecurityCommandHandler(IActionHandler actionHandler, ISecurityUserRepository repositorySecurityUser, ICommandHandler<T> next)
        {
            Contract.Requires(actionHandler != null);
            Contract.Requires(repositorySecurityUser != null);
            Contract.Requires(next != null);    

            _actionHandler = actionHandler;
            _next = next;
            _repositorySecurityUser = repositorySecurityUser;

        }

        public CommandValidation Execute(T command)
        {
            var user = _repositorySecurityUser.GetUser(command.SecurityToken);
            

            var action = user.CreateAction(_actionHandler, command);
            if (action.CanBeExecuted())
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