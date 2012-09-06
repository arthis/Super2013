using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;
using Super.Contabilita.Events.Appaltatore;
using Super.Contabilita.Events.CategoriaCommerciale;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Events.Lotto;

namespace Super.Contabilita.Projection
{
    public class ProjectionHandlerService : ProjectionHandlerServiceBase
    {
     

        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder);

            handlerHelper.Add<ImpiantoCreated>(_handlers, new ImpiantoProjection());
            handlerHelper.Add<ImpiantoUpdated>(_handlers, new ImpiantoProjection());
            handlerHelper.Add<ImpiantoDeleted>(_handlers, new ImpiantoProjection());


            handlerHelper.Add<LottoCreated>(_handlers, new LottoProjection());
            handlerHelper.Add<LottoUpdated>(_handlers, new LottoProjection());
            handlerHelper.Add<LottoDeleted>(_handlers, new LottoProjection());


            handlerHelper.Add<AppaltatoreCreated>(_handlers, new AppaltatoreProjection());
            handlerHelper.Add<AppaltatoreUpdated>(_handlers, new AppaltatoreProjection());
            handlerHelper.Add<AppaltatoreDeleted>(_handlers, new AppaltatoreProjection());

            handlerHelper.Add<CategoriaCommercialeCreated>(_handlers, new CategoriaCommercialeProjection());
            handlerHelper.Add<CategoriaCommercialeUpdated>(_handlers, new CategoriaCommercialeProjection());
            handlerHelper.Add<CategoriaCommercialeDeleted>(_handlers, new CategoriaCommercialeProjection());

        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            //Events
            bus.Subscribe<ImpiantoCreated>(subscriptionId, Execute);
            bus.Subscribe<ImpiantoUpdated>(subscriptionId, Execute);
            bus.Subscribe<ImpiantoDeleted>(subscriptionId, Execute);

            bus.Subscribe<LottoCreated>(subscriptionId, Execute);
            bus.Subscribe<LottoUpdated>(subscriptionId, Execute);
            bus.Subscribe<LottoDeleted>(subscriptionId, Execute);

            bus.Subscribe<AppaltatoreCreated>(subscriptionId, Execute);
            bus.Subscribe<AppaltatoreUpdated>(subscriptionId, Execute);
            bus.Subscribe<AppaltatoreDeleted>(subscriptionId, Execute);

            bus.Subscribe<CategoriaCommercialeCreated>(subscriptionId, Execute);
            bus.Subscribe<CategoriaCommercialeUpdated>(subscriptionId, Execute);
            bus.Subscribe<CategoriaCommercialeDeleted>(subscriptionId, Execute);
        }

        
    }

    
}
