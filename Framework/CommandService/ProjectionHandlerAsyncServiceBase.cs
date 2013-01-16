using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;

namespace CommandService
{
    public abstract class ProjectionHandlerAsyncServiceBase : IProjectionHandlerAsyncService
    {
        protected readonly Dictionary<Type, IEnumerable<Projection>> _handlers = new Dictionary<Type, IEnumerable<Projection>>();

        public abstract void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder,IBus bus);

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