using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;

namespace CommandService
{
    public abstract class ProjectionHandlerServiceBase : IProjectionHandlerService
    {
        protected readonly Dictionary<Type, Action<IEvent>> _handlers = new Dictionary<Type, Action<IEvent>>();

        public abstract void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder);
        public abstract void Subscribe(IBus bus);

        public void Execute(IEvent evt)
        {
            Contract.Requires<ArgumentNullException>(evt != null);

            var type = evt.GetType();
            if (_handlers.ContainsKey(type))
                _handlers[type](evt);
            else
                throw new HandlerForDomainEventNotFoundException(string.Format("No handler found for the event '{0}'", evt.GetType()));

        }
    }
}