using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Saga.Handlers
{
    public class MessageHandlerService 
    {
        private readonly IBus _bus;
        private readonly Dictionary<Type, Action<IMessage>> _handlers = new Dictionary<Type, Action<IMessage>>();

        public MessageHandlerService(IBus bus)
        {
            _bus = bus;
        }

        public void InitHandlers(ISagaRepository repository)
        {
            var sagaHandler = new SagaHandler(repository);

            sagaHandler.Add(_handlers, new InterventoRotScheduledHandler(repository, _bus));
            sagaHandler.Add(_handlers, new InterventoRotManScheduledHandler(repository, _bus));
            sagaHandler.Add(_handlers, new InterventoAmbScheduledHandler(repository, _bus));

            sagaHandler.Add(_handlers, new InterventoConsuntivatoRotResoHandler(repository, _bus));
            sagaHandler.Add(_handlers, new InterventoConsuntivatoRotNonResoHandler(repository, _bus));
            sagaHandler.Add(_handlers, new InterventoConsuntivatoRotNonResoTrenitaliaHandler(repository, _bus));

            sagaHandler.Add(_handlers, new InterventoConsuntivatoRotManResoHandler(repository, _bus));
            sagaHandler.Add(_handlers, new InterventoConsuntivatoRotManNonResoHandler(repository, _bus));
            sagaHandler.Add(_handlers, new InterventoConsuntivatoRotManNonResoTrenitaliaHandler(repository, _bus));

            sagaHandler.Add(_handlers, new InterventoConsuntivatoAmbResoHandler(repository, _bus));
            sagaHandler.Add(_handlers, new InterventoConsuntivatoAmbNonResoHandler(repository, _bus));
            sagaHandler.Add(_handlers, new InterventoConsuntivatoAmbNonResoTrenitaliaHandler(repository, _bus));
        }

        public void Subscribe()
        {
            string subscriptionId = "Super";

            _bus.Subscribe<InterventoRotGeneratedFromSchedulazione>(subscriptionId, Execute);
            _bus.Subscribe<InterventoRotManGeneratedFromSchedulazione>(subscriptionId, Execute);
            _bus.Subscribe<InterventoAmbGeneratedFromSchedulazione>(subscriptionId, Execute);

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
