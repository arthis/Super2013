using CommandService;
using CommonDomain;
using Super.Contabilita.Events.AreaIntervento;

namespace Super.Contabilita.Projection
{
    public class ProjectionHandlerService : IProjectionHandlerService
    {
        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            //Events
            //to dry
            bus.Subscribe<AreaInterventoCreated>(subscriptionId, evt => new AreaInterventoProjection().Handle(evt));
            bus.Subscribe<AreaInterventoUpdated>(subscriptionId, evt => new AreaInterventoProjection().Handle(evt));
            bus.Subscribe<AreaInterventoDeleted>(subscriptionId, evt => new AreaInterventoProjection().Handle(evt));
        }
    }
}
