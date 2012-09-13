namespace CommonDomain.Core.Handlers
{
    public interface IPortHandler<in TEvent> where TEvent : IMessage
    {
        void port(TEvent command);
    }
}