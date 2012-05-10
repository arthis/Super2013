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
        private readonly Dictionary<Type, Func<Object, ICommandValidation>> _handlers = new Dictionary<Type, Func<Object, ICommandValidation>>();



        public void InitHandlers(IRepository repositoryEvent)
        {
            _handlers.Add(typeof(CreateAreaIntervento),
                          (cmd) => new CreateAreaInterventoHandler(repositoryEvent).Execute((CreateAreaIntervento)cmd));
            _handlers.Add(typeof(UpdateAreaIntervento),
                          (cmd) => new UpdateAreaInterventoHandler(repositoryEvent).Execute((UpdateAreaIntervento)cmd));
            _handlers.Add(typeof(DeleteAreaIntervento),
                          (cmd) => new DeleteAreaInterventoHandler(repositoryEvent).Execute((DeleteAreaIntervento)cmd));
        }

        public ICommandValidation Execute(ICommand command)
        {
            Contract.Requires<ArgumentNullException>(command != null);

            throw new NotImplementedException();

            var type = command.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](command);

            //return new CommandValidation(false);

            

        }
    }
}
