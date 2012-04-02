namespace Cqrs.Commanding.ServiceModel
{
    public interface ICommandService
    {
        void Execute(ICommand command);
    }
}