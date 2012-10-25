using CommandService;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;

namespace Super.Programmazione.Projection
{
    public class ProjectionHandlerSyncService : ProjectionHandlerSyncServiceBase
    {
        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder, _handlers,  Execute);

            //handlerHelper.Subscribe<ScenarioCreated>(new ScenarioProjection());
            //handlerHelper.Subscribe<DescriptionOfScenarioChanged>(new ScenarioProjection());
            //handlerHelper.Subscribe<ScenarioCancelled>(new ScenarioProjection());
            //handlerHelper.Subscribe<ScenarioPromotedToPlan>(new ScenarioProjection());

        }

    }
}