using CommonDomain;

namespace CommandService
{
    public interface IProjectionHandlerService
    {
        void Subscribe(IBus bus);
    }
}