using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Projection
{
    public class ProjectionHandlerService : ProjectionHandlerServiceBase
    {
        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder,IBus bus)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder, _handlers, bus, Execute);

            handlerHelper.Subscribe<ScenarioCreated>(new ScenarioProjection());
            handlerHelper.Subscribe<DescriptionOfScenarioChanged>(new ScenarioProjection());
            handlerHelper.Subscribe<ScenarioCancelled>(new ScenarioProjection());
            handlerHelper.Subscribe<ScenarioPromotedToPlan>(new ScenarioProjection());

        }
      
    }
}
