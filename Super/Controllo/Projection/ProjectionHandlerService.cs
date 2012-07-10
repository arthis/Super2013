using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;

namespace Super.Controllo.Projection
{
    public class ProjectionHandlerService : IProjectionHandlerService
    {

        private readonly Dictionary<Type, Action<IEvent>> _handlers = new Dictionary<Type, Action<IEvent>>();

        public void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder);

            //handlerHelper.Add<InterventoRotProgrammato>(_handlers, new ConsuntivazioneRotProjection());
            //handlerHelper.Add<InterventoRotManProgrammato>(_handlers, new ConsuntivazioneRotManProjection());
            //handlerHelper.Add<InterventoAmbProgrammato>(_handlers, new ConsuntivazioneAmbProjection());

        }

        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            //Events
            //bus.Subscribe<InterventoRotProgrammato>(subscriptionId, Execute);
            //bus.Subscribe<InterventoRotManProgrammato>(subscriptionId, Execute);
            //bus.Subscribe<InterventoAmbProgrammato>(subscriptionId, Execute);


        }

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
