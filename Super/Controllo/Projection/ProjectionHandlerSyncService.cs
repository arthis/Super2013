using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;

namespace Super.Controllo.Projection
{
    public class ProjectionHandlerSyncService : ProjectionHandlerSyncServiceBase
    {

        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder,_handlers,  Execute);

            //handlerHelper.Subscribe<InterventoRotProgrammato>(_handlers, new ConsuntivazioneRotProjection());
            //handlerHelper.Subscribe<InterventoRotManProgrammato>(_handlers, new ConsuntivazioneRotManProjection());
            //handlerHelper.Subscribe<InterventoAmbProgrammato>(_handlers, new ConsuntivazioneAmbProjection());

        }
    
    }
}
