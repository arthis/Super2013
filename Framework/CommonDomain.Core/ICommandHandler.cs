namespace CommonDomain.Core
{
    public interface ICommandHandler<in TCommand> where TCommand : IMessage
    {
        CommandValidation Execute(TCommand command);
    }


   
}