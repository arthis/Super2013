using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Persistence;
using Super.Administration.Commands.AreaIntervento;

namespace Super.Administration.Handlers
{
    public class CommandHandlerService
    {
        private readonly Dictionary<Type, Action<Object>> _handlers = new Dictionary<Type, Action<Object>>();



        public void InitHandlers(IRepository repositoryEvent)
        {
            _handlers.Add(typeof(CreateAreaIntervento),
                          (cmd) => new CreateAreaInterventoHandler(repositoryEvent).Execute((CreateAreaIntervento)cmd));
            _handlers.Add(typeof(UpdateAreaIntervento),
                          (cmd) => new UpdateAreaInterventoHandler(repositoryEvent).Execute((UpdateAreaIntervento)cmd));
            _handlers.Add(typeof(DeleteAreaIntervento),
                          (cmd) => new DeleteAreaInterventoHandler(repositoryEvent).Execute((DeleteAreaIntervento)cmd));
        }

        public void Execute(ICommand command)
        {
            Contract.Requires<ArgumentNullException>(command != null);

            var type = command.GetType();
            if (_handlers.ContainsKey(type))
                _handlers[type](command);

        }
    }
}
