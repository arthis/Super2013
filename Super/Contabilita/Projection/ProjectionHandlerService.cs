using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Projection
{
    public class ProjectionHandlerService : IProjectionHandlerService
    {
        private readonly Dictionary<Type, Action<IEvent>> _handlers = new Dictionary<Type, Action<IEvent>>();

        public void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder);

            handlerHelper.Add<ImpiantoCreated>(_handlers, new ImpiantoProjection());
            handlerHelper.Add<ImpiantoUpdated>(_handlers, new ImpiantoProjection());
            handlerHelper.Add<ImpiantoDeleted>(_handlers, new ImpiantoProjection());


            handlerHelper.Add<LottoCreated>(_handlers, new LottoProjection());
            handlerHelper.Add<LottoUpdated>(_handlers, new LottoProjection());
            handlerHelper.Add<LottoDeleted>(_handlers, new LottoProjection());

        }

        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            //Events
            bus.Subscribe<ImpiantoCreated>(subscriptionId, Execute);
            bus.Subscribe<ImpiantoUpdated>(subscriptionId, Execute);
            bus.Subscribe<ImpiantoDeleted>(subscriptionId, Execute);

            bus.Subscribe<LottoCreated>(subscriptionId, Execute);
            bus.Subscribe<LottoUpdated>(subscriptionId, Execute);
            bus.Subscribe<LottoDeleted>(subscriptionId, Execute);
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
