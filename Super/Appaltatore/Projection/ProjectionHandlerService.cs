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

            //Consuntivazione Rotabile Projection
            bus.Subscribe<InterventoRotProgrammato>(subscriptionId, evt => new ConsuntivazioneRotProjection().Handle(evt));

            //Consuntivazione Rotabile in manutenzione Projection
            bus.Subscribe<InterventoRotManProgrammato>(subscriptionId, evt => new ConsuntivazioneRotManProjection().Handle(evt));

            //Consuntivazione Ambiente Projection
            bus.Subscribe<InterventoAmbProgrammato>(subscriptionId, evt => new ConsuntivazioneAmbProjection().Handle(evt));
        }
    }
}
