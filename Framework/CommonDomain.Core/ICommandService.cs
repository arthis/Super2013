namespace CommonDomain.Core
{
    public interface ICommandService
    {
        void Init();
        CommandValidation Execute(IMessage commandBase);
    }
}