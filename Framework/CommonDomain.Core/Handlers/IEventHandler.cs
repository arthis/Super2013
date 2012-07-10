namespace CommonDomain.Core.Handlers
{
    public interface IEventHandler<TEvent> where TEvent : IMessage
    {
        void Handle(TEvent @event);
    }
}