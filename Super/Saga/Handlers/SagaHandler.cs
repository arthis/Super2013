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

        public SagaHandler(ISagaRepository sagaRepository )
        {
            Contract.Requires(sagaRepository!=null);

            _sagaRepository = sagaRepository;
        }

        public void Add<T>(Dictionary<Type, Action<IMessage>> dictionnary, IEventHandler<T> finalHandler) where T : IMessage
        {
            dictionnary.Add(typeof(T), (evt) => new HandleMessageOnlyOnce<T>(_sagaRepository, finalHandler).Handle((T)evt));
        }
    }
}