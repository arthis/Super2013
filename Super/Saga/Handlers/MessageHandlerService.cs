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
        private readonly Dictionary<Type, Action<IMessage>> _handlers = new Dictionary<Type, Action<IMessage>>();

        public MessageHandlerService(IBus bus)
        {
            _bus = bus;
        }

        public void InitHandlers(ISagaRepository repository)
        {
            SagaHandler.Add<InterventoRotPianificato>(_handlers, new InterventoRotPianificatoHandler(repository, _bus));
            SagaHandler.Add<InterventoRotManPianificato>(_handlers, new InterventoRotManPianificatoHandler(repository, _bus));
            SagaHandler.Add<InterventoAmbPianificato>(_handlers, new InterventoAmbPianificatoHandler(repository, _bus));

            SagaHandler.Add<InterventoConsuntivatoRotReso>(_handlers, new InterventoConsuntivatoRotResoHandler(repository, _bus));
            SagaHandler.Add<InterventoConsuntivatoRotNonReso>(_handlers, new InterventoConsuntivatoRotNonResoHandler(repository, _bus));
            SagaHandler.Add<InterventoConsuntivatoRotNonResoTrenitalia>(_handlers, new InterventoConsuntivatoRotNonResoTrenitaliaHandler(repository, _bus));

            SagaHandler.Add<InterventoConsuntivatoRotManReso>(_handlers, new InterventoConsuntivatoRotManResoHandler(repository, _bus));
            SagaHandler.Add<InterventoConsuntivatoRotManNonReso>(_handlers, new InterventoConsuntivatoRotManNonResoHandler(repository, _bus));
            SagaHandler.Add<InterventoConsuntivatoRotManNonResoTrenitalia>(_handlers, new InterventoConsuntivatoRotManNonResoTrenitaliaHandler(repository, _bus));

            SagaHandler.Add<InterventoConsuntivatoAmbReso>(_handlers, new InterventoConsuntivatoAmbResoHandler(repository, _bus));
            SagaHandler.Add<InterventoConsuntivatoAmbNonReso>(_handlers, new InterventoConsuntivatoAmbNonResoHandler(repository, _bus));
            SagaHandler.Add<InterventoConsuntivatoAmbNonResoTrenitalia>(_handlers, new InterventoConsuntivatoAmbNonResoTrenitaliaHandler(repository, _bus));
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
