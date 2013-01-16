using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;

namespace CommandService
{
    public abstract class ProjectionHandlerSyncServiceBase : IProjectionHandlerSyncService
    {
        protected readonly Dictionary<Type, IEnumerable<Projection>> _handlers = new Dictionary<Type, IEnumerable<Projection>>();

        public abstract void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder);

        public bool IsHandled(IEvent evt)
        {
            var type = evt.GetType();
            return _handlers.ContainsKey(type);
        }

        public void Execute(IEvent evt)
        {

            var type = evt.GetType();
            if (_handlers.ContainsKey(type))
                foreach (var projection in _handlers[type])
                {
                    projection.Projects(evt);
                }
            else
                throw new HandlerForMessageNotFoundException(string.Format("No handler found for the event '{0}'", evt.GetType()));

        }
    }
}