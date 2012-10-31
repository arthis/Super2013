using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{



    public class SecurityCommandHandler<T> : ICommandHandler<T> where T : ICommand  
    {

        private readonly IActionFactory _actionFactory;
        private ICommandHandler<T> _next;
        private readonly ISecurityUserRepository _repositorySecurityUser;

        public SecurityCommandHandler(IActionFactory actionFactory, ISecurityUserRepository repositorySecurityUser, ICommandHandler<T> next)
        {
            Contract.Requires(actionFactory != null);
            Contract.Requires(repositorySecurityUser != null);
            Contract.Requires(next != null);    

            _actionFactory = actionFactory;
            _next = next;
            _repositorySecurityUser = repositorySecurityUser;

        }

        public CommandValidation Execute(T command)
        {
            var user = _repositorySecurityUser.GetSecurityUser(command.SecurityToken);

            var action = user.CreateAction(_actionFactory, command);
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