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

            bus.Subscribe<InterventoRotProgrammato>(subscriptionId, evt => new ReadOnce<InterventoRotProgrammato>()
                                                                                .Handle(evt, new ConsuntivazioneRotProjection()));

            bus.Subscribe<InterventoRotManProgrammato>(subscriptionId, evt => new ReadOnce<InterventoRotManProgrammato>()
                                                                                .Handle(evt, new ConsuntivazioneRotManProjection()));

            bus.Subscribe<InterventoAmbProgrammato>(subscriptionId, evt => new ReadOnce<InterventoAmbProgrammato>()
                                                                                .Handle(evt, new ConsuntivazioneAmbProjection()));

        }
    }
}
