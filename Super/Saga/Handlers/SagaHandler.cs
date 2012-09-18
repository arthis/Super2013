using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;

namespace Super.Saga.Handlers
{
    public class SagaHandler
    {
        private readonly ISagaRepository _sagaRepository;
        private readonly Dictionary<Type, Action<IMessage>> _dictionary;
        private readonly IBus _bus;
        private readonly Action<IMessage> _execute;

        public SagaHandler(ISagaRepository sagaRepository, Dictionary<Type, Action<IMessage>> dictionary, IBus bus, Action<IMessage> execute )
        {
            Contract.Requires(sagaRepository!=null);
            Contract.Requires(dictionary!=null);
            Contract.Requires(bus!=null);
            Contract.Requires(execute!=null);

            _sagaRepository = sagaRepository;
            _dictionary = dictionary;
            _bus = bus;
            _execute = execute;
        }

        public void Add<T>(IEventHandler<T> finalHandler) where T : IMessage
        {
            string subscriptionId = "Super";

            _dictionary.Add(typeof(T), (evt) => new HandleMessageOnlyOnce<T>(_sagaRepository, finalHandler).Handle((T)evt));

            _bus.Subscribe<T>(subscriptionId, (msg) => _execute(msg));
        }
    }
}