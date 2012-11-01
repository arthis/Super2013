using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;

namespace CommandService
{
    public abstract class ProjectionHandlerAsyncServiceBase : IProjectionHandlerAsyncService
    {
        protected readonly Dictionary<Type, Action<IEvent>> _handlers = new Dictionary<Type, Action<IEvent>>();

        public abstract void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder,IBus bus);

        public void Execute(IEvent evt)
        {

            var type = evt.GetType();
            if (_handlers.ContainsKey(type))
                _handlers[type](evt);
            else
                throw new HandlerForMessageNotFoundException(string.Format("No handler found for the event '{0}'", evt.GetType()));

        }
    }
}