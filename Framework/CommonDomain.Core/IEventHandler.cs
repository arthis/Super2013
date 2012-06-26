namespace CommonDomain.Core
{
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        void Handle(TEvent @event, IEventHandler<TEvent> next);
    }
}