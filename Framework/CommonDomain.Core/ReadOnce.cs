namespace CommonDomain.Core
{
    public class ReadOnce<T> : ICommandHandler<T> where T : IMessage
    {

        public CommandValidation Execute(T command, ICommandHandler<T> next)
        {
            //check that the commitid is not part of the eventstore already

            return next.Execute(command, next);
        }
    }
}