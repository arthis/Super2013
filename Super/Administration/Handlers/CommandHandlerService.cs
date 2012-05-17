using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Administration.Commands.AreaIntervento;


namespace Super.Administration.Handlers
{
    public class CommandHandlerService
    {
        private readonly Dictionary<Type, Func<Object, CommandValidation>> _handlers = new Dictionary<Type, Func<Object, CommandValidation>>();



        public void InitHandlers(IRepository repositoryEvent)
        {
            _handlers.Add(typeof(CreateAreaIntervento),
                          (cmd) => new CreateAreaInterventoHandler(repositoryEvent).Execute((CreateAreaIntervento)cmd));
            _handlers.Add(typeof(UpdateAreaIntervento),
                          (cmd) => new UpdateAreaInterventoHandler(repositoryEvent).Execute((UpdateAreaIntervento)cmd));
            _handlers.Add(typeof(DeleteAreaIntervento),
                          (cmd) => new DeleteAreaInterventoHandler(repositoryEvent).Execute((DeleteAreaIntervento)cmd));

            
        }

        public CommandValidation Execute(ICommand commandBase)
        {
            Contract.Requires<ArgumentNullException>(commandBase != null);


            var type = commandBase.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](commandBase);

            throw new Exception(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }
    }

}
