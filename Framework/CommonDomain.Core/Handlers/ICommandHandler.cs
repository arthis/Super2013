namespace CommonDomain.Core.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : IMessage
    {
        CommandValidation Execute(TCommand command);
    }

    public interface IFinalHandler<in TCommand> : ICommandHandler<TCommand> where TCommand : IMessage
    {
        ISession Session { get; set; }   
    }
    



   
}