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
    public class ProjectionHandlerAsyncService : ProjectionHandlerAsyncServiceBase
    {

        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder, IBus bus)
        {
            var handlerHelper = new EventHandlerHelper("Appaltatore", projectionRepositoryBuilder, _handlers, bus, Execute);

            handlerHelper.Subscribe( new ConsuntivazioneRotProjection());
            handlerHelper.Subscribe( new ConsuntivazioneRotManProjection());
            handlerHelper.Subscribe( new ConsuntivazioneAmbProjection());

        }

    }
}
