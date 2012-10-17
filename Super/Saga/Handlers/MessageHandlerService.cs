using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Saga.Handlers.Intervento;

namespace Super.Saga.Handlers
{
    public class MessageHandlerService 
    {
        
        private readonly Dictionary<Type, Action<IMessage>> _handlers = new Dictionary<Type, Action<IMessage>>();


        public void InitHandlers(ISagaRepository repository, IBus bus)
        {
            var sagaHandler = new SagaHandler(repository, _handlers, bus, Execute);

            sagaHandler.Add(new InterventoRotCreatedHandler(repository, bus));
            sagaHandler.Add(new InterventoRotManCreatedHandler(repository, bus));
            sagaHandler.Add(new InterventoAmbCreatedHandler(repository, bus));

            sagaHandler.Add(new InterventoRotConsuntivatoResoHandler(repository, bus));
            sagaHandler.Add(new InterventoRotConsuntivatoNonResoHandler(repository, bus));
            sagaHandler.Add(new InterventoRotConsuntivatoNonResoTrenitaliaHandler(repository, bus));

            sagaHandler.Add(new InterventoRotManConsuntivatoResoHandler(repository, bus));
            sagaHandler.Add(new InterventoRotManConsuntivatoNonResoHandler(repository, bus));
            sagaHandler.Add(new InterventoRotManConsuntivatoNonResoTrenitaliaHandler(repository, bus));

            sagaHandler.Add(new InterventoAmbConsuntivatoResoHandler(repository, bus));
            sagaHandler.Add(new InterventoAmbConsuntivatoNonResoHandler(repository, bus));
            sagaHandler.Add(new InterventoAmbConsuntivatoNonResoTrenitaliaHandler(repository, bus));
        }

        public void Execute(IMessage message)
        {
            Contract.Requires(message != null);

            var type = message.GetType();
            if (_handlers.ContainsKey(type))
                 _handlers[type](message);
            else
                throw new HandlerForMessageNotFoundException(string.Format("No handler found for the command '{0}'", message.GetType()));
            
        }

    }

   
}
