using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Saga.Handlers
{
    public static class SagaHandler
    {
        public static void Add<T>(Dictionary<Type, Action<IMessage>> dictionnary, IEventHandler<T> finalHandler) where T : IMessage
        {
            dictionnary.Add(typeof(T), (evt) => new ReadOnce<T>().Handle((T)evt, finalHandler));
        }
    }
}