using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Projection
{
    public class ProjectionHandlerService : ProjectionHandlerServiceBase
    {

        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder);

            handlerHelper.Add(_handlers, new ConsuntivazioneRotProjection());
            handlerHelper.Add(_handlers, new ConsuntivazioneRotManProjection());
            handlerHelper.Add(_handlers, new ConsuntivazioneAmbProjection());

        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            //Events
            bus.Subscribe<InterventoRotProgrammato>(subscriptionId, Execute);
            bus.Subscribe<InterventoRotManProgrammato>(subscriptionId, Execute);
            bus.Subscribe<InterventoAmbProgrammato>(subscriptionId, Execute);


        }

        
    }
}
