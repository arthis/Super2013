using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using EventStore;
using EventStore.Persistence.SqlPersistence.SqlDialects;
using EventStore.Serialization;

namespace CommandService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CommandWebService<TSession> : ICommandWebService where TSession : ISession
    {
        private ICommandHandlerService<TSession> _commandHandler;
        
        public CommandWebService(ICommandHandlerService<TSession> commandHandlerService)
        {
            _commandHandler = commandHandlerService;
            
        }

        public ExecuteResponse Execute(CommandBase command)
        {
            Contract.Ensures(Contract.Result<ExecuteResponse>() != null);

            try
            {
                var validation = _commandHandler.Execute(command);
                return new ExecuteResponse(validation);
            }
            catch (Exception ex)
            {
                return new ExecuteResponse( new CommandValidation(new ValidationMessage("Error",ex.ToString())));
            }

        }

        
        


        public string Login(string username, string password)
        {
            return Guid.NewGuid().ToString();
        }
    }


}