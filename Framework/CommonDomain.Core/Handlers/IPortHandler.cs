namespace CommonDomain.Core.Handlers
{
    public interface IPortHandler<in TEvent, out TCommand> 
        where TEvent : IEvent
        where TCommand : ICommand
    {
        TCommand Port(TEvent evt);
        
    }
}