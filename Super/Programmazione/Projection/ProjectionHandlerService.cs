using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;

namespace Super.Programmazione.Projection
{
    public class ProjectionHandlerService : ProjectionHandlerServiceBase
    {

        

        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder,IBus bus)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder, _handlers, bus, Execute);

            //handlerHelper.Subscribe<InterventoRotProgrammato>(_handlers, new ConsuntivazioneRotProjection());
            //handlerHelper.Subscribe<InterventoRotManProgrammato>(_handlers, new ConsuntivazioneRotManProjection());
            //handlerHelper.Subscribe<InterventoAmbProgrammato>(_handlers, new ConsuntivazioneAmbProjection());

        }
      
    }
}
