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

            sagaHandler.Add(new InterventoRotScheduledHandler(repository, bus));
            sagaHandler.Add(new InterventoRotManScheduledHandler(repository, bus));
            sagaHandler.Add(new InterventoAmbScheduledHandler(repository, bus));

            sagaHandler.Add(new InterventoConsuntivatoRotResoHandler(repository, bus));
            sagaHandler.Add(new InterventoConsuntivatoRotNonResoHandler(repository, bus));
            sagaHandler.Add(new InterventoConsuntivatoRotNonResoTrenitaliaHandler(repository, bus));

            sagaHandler.Add(new InterventoConsuntivatoRotManResoHandler(repository, bus));
            sagaHandler.Add(new InterventoConsuntivatoRotManNonResoHandler(repository, bus));
            sagaHandler.Add(new InterventoConsuntivatoRotManNonResoTrenitaliaHandler(repository, bus));

            sagaHandler.Add(new InterventoConsuntivatoAmbResoHandler(repository, bus));
            sagaHandler.Add(new InterventoConsuntivatoAmbNonResoHandler(repository, bus));
            sagaHandler.Add(new InterventoConsuntivatoAmbNonResoTrenitaliaHandler(repository, bus));
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
