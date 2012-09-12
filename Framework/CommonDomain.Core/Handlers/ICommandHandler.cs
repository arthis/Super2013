namespace CommonDomain.Core.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : IMessage
    {
        
        CommandValidation Execute(TCommand command);
    }

    
}