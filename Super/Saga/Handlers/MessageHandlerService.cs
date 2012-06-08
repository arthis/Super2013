using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Programmazione.Events;

namespace Super.Saga.Handlers
{
    public class MessageHandlerService 
    {
        public void Subscribe(ISagaRepository repository, IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<InterventoRotPianificato>(subscriptionId, evt => new InterventoRotPianificatoHandler(repository, bus).Handle(evt));
            bus.Subscribe<InterventoRotManPianificato>(subscriptionId, evt => new InterventoRotManPianificatoHandler(repository, bus).Handle(evt));
            bus.Subscribe<InterventoAmbPianificato>(subscriptionId, evt => new InterventoAmbPianificatoHandler(repository, bus).Handle(evt));

            bus.Subscribe<ConsuntivatoRotReso>(subscriptionId, evt => new ConsuntivatoRotResoHandler(repository, bus).Handle(evt));
            bus.Subscribe<ConsuntivatoRotManReso>(subscriptionId, evt => new ConsuntivatoRotManHandler(repository, bus).Handle(evt));
            bus.Subscribe<ConsuntivatoAmbReso>(subscriptionId, evt => new ConsuntivatoAmbResoHandler(repository, bus).Handle(evt));

            

        }

    }

   
}
