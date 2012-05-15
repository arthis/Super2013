using CommonDomain;

namespace CommandService
{
    public interface ICommandService
    {
        void Init();
        ICommandValidation Execute(ICommand commandBase);
    }
}