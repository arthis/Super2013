namespace CommonDomain.Core
{
    public interface ICommandHandler<TCommand> where TCommand : IMessage
    {
        CommandValidation Execute(TCommand command, ICommandHandler<TCommand> next);
    }


   
}