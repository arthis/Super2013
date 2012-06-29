using CommandService;
using CommonDomain;
using Super.Appaltatore.Events.Programmazione;

namespace Super.Appaltatore.Projection
{
    public class ProjectionHandlerService : IProjectionHandlerService
    {
        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<InterventoRotProgrammato>(subscriptionId, evt => new HandleEventOnlyOnceHandler<InterventoRotProgrammato>()
                                                                                .Handle(evt, new ConsuntivazioneRotProjection()));

            bus.Subscribe<InterventoRotManProgrammato>(subscriptionId, evt => new HandleEventOnlyOnceHandler<InterventoRotManProgrammato>()
                                                                                .Handle(evt, new ConsuntivazioneRotManProjection()));

            bus.Subscribe<InterventoAmbProgrammato>(subscriptionId, evt => new HandleEventOnlyOnceHandler<InterventoAmbProgrammato>()
                                                                                .Handle(evt, new ConsuntivazioneAmbProjection()));

        }
    }
}
