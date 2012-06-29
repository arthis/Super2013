using System;

namespace CommonDomain.Core
{
    public interface IEventHandler<TEvent> where TEvent : IMessage
    {
        void Handle(TEvent @event, IEventHandler<TEvent> next);
    }
}