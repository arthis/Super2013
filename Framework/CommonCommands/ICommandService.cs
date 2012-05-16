using CommonDomain;
using CommonDomain.Core;

namespace CommandService
{
    public interface ICommandService
    {
        void Init();
        CommandValidation Execute(ICommand commandBase);
    }
}