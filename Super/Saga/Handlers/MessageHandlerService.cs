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

            bus.Subscribe<InterventoConsuntivatoRotReso>(subscriptionId, evt => new InterventoRotConsuntivatoHandler(repository, bus).Handle(evt));
            bus.Subscribe<InterventoConsuntivatoRotNonReso>(subscriptionId, evt => new InterventoRotConsuntivatoHandler(repository, bus).Handle(evt));
            bus.Subscribe<InterventoConsuntivatoRotNonResoTrenitalia>(subscriptionId, evt => new InterventoRotConsuntivatoHandler(repository, bus).Handle(evt));

            bus.Subscribe<InterventoConsuntivatoRotManReso>(subscriptionId, evt => new InterventoRotManConsuntivatoHandler(repository, bus).Handle(evt));
            bus.Subscribe<InterventoConsuntivatoRotManNonReso>(subscriptionId, evt => new InterventoRotManConsuntivatoHandler(repository, bus).Handle(evt));
            bus.Subscribe<InterventoConsuntivatoRotManNonResoTrenitalia>(subscriptionId, evt => new InterventoRotManConsuntivatoHandler(repository, bus).Handle(evt));

            bus.Subscribe<InterventoConsuntivatoAmbReso>(subscriptionId, evt => new InterventoAmbConsuntivatoHandler(repository, bus).Handle(evt));
            bus.Subscribe<InterventoConsuntivatoAmbNonReso>(subscriptionId, evt => new InterventoAmbConsuntivatoHandler(repository, bus).Handle(evt));
            bus.Subscribe<InterventoConsuntivatoAmbNonResoTrenitalia>(subscriptionId, evt => new InterventoAmbConsuntivatoHandler(repository, bus).Handle(evt));

            

        }

    }

   
}
