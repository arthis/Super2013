using CommandService;
using CommonDomain.Core.Handlers.Events;
using CommonDomain.Persistence;

namespace Super.Appaltatore.Projection
{
    public class ProjectionHandlerSyncService : ProjectionHandlerSyncServiceBase
    {

        public override void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder)
        {
            var handlerHelper = new EventHandlerHelper(projectionRepositoryBuilder, _handlers,  Execute);

            //handlerHelper.Subscribe(new ConsuntivazioneRotProjection());
            //handlerHelper.Subscribe(new ConsuntivazioneRotManProjection());
            //handlerHelper.Subscribe(new ConsuntivazioneAmbProjection());

        }

    }
}