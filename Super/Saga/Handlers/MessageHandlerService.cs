using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Programmazione.Events;

namespace Super.Saga.Handlers
{
    public class MessageHandlerService 
    {
        private readonly IBus _bus;
        private readonly Dictionary<Type, Action<Object>> _handlers = new Dictionary<Type, Action<Object>>();

        public MessageHandlerService(IBus bus)
        {
            _bus = bus;
        }

        public void InitHandlers(ISagaRepository repository)
        {
            _handlers.Add(typeof(InterventoRotPianificato),
                        evt => new InterventoRotPianificatoHandler(repository, _bus).Handle((InterventoRotPianificato)evt));
            _handlers.Add(typeof(InterventoRotManPianificato),
                        evt => new InterventoRotManPianificatoHandler(repository, _bus).Handle((InterventoRotManPianificato)evt));
            _handlers.Add(typeof(InterventoAmbPianificato),
                        evt => new InterventoAmbPianificatoHandler(repository, _bus).Handle((InterventoAmbPianificato)evt));

            _handlers.Add(typeof(InterventoConsuntivatoRotReso),
                        evt => new InterventoRotConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoRotReso)evt));
            _handlers.Add(typeof(InterventoConsuntivatoRotNonReso),
                        evt => new InterventoRotConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoRotNonReso)evt));
            _handlers.Add(typeof(InterventoConsuntivatoRotNonResoTrenitalia),
                        evt => new InterventoRotConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoRotNonResoTrenitalia)evt));

            _handlers.Add(typeof(InterventoConsuntivatoRotManReso),
                        evt => new InterventoRotManConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoRotManReso)evt));
            _handlers.Add(typeof(InterventoConsuntivatoRotManNonReso),
                        evt => new InterventoRotManConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoRotManNonReso)evt));
            _handlers.Add(typeof(InterventoConsuntivatoRotManNonResoTrenitalia),
                        evt => new InterventoRotManConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoRotManNonResoTrenitalia)evt));

            _handlers.Add(typeof(InterventoConsuntivatoAmbReso),
                       evt => new InterventoAmbConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoAmbReso)evt));
            _handlers.Add(typeof(InterventoConsuntivatoAmbNonReso),
                        evt => new InterventoAmbConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoAmbNonReso)evt));
            _handlers.Add(typeof(InterventoConsuntivatoAmbNonResoTrenitalia),
                        evt => new InterventoAmbConsuntivatoHandler(repository, _bus).Handle((InterventoConsuntivatoAmbNonResoTrenitalia)evt));

        }

        public void Subscribe()
        {
            string subscriptionId = "Super";

            _bus.Subscribe<InterventoRotPianificato>(subscriptionId, Execute);
            _bus.Subscribe<InterventoRotManPianificato>(subscriptionId, Execute);
            _bus.Subscribe<InterventoAmbPianificato>(subscriptionId, Execute);

            _bus.Subscribe<InterventoConsuntivatoRotReso>(subscriptionId, Execute);
            _bus.Subscribe<InterventoConsuntivatoRotNonReso>(subscriptionId, Execute);
            _bus.Subscribe<InterventoConsuntivatoRotNonResoTrenitalia>(subscriptionId, Execute);

            _bus.Subscribe<InterventoConsuntivatoRotManReso>(subscriptionId, Execute);
            _bus.Subscribe<InterventoConsuntivatoRotManNonReso>(subscriptionId, Execute);
            _bus.Subscribe<InterventoConsuntivatoRotManNonResoTrenitalia>(subscriptionId, Execute);

            _bus.Subscribe<InterventoConsuntivatoAmbReso>(subscriptionId, Execute);
            _bus.Subscribe<InterventoConsuntivatoAmbNonReso>(subscriptionId, Execute);
            _bus.Subscribe<InterventoConsuntivatoAmbNonResoTrenitalia>(subscriptionId, Execute);
        }

        public void Execute(IMessage message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            var type = message.GetType();
            if (_handlers.ContainsKey(type))
                 _handlers[type](message);
            else
                throw new HandlerForDomainEventNotFoundException(string.Format("No handler found for the command '{0}'", message.GetType()));
            
        }

    }

   
}
