using System;

namespace CommonDomain.Persistence
{
    public interface IProjectionRepository
    {
        TEvent GetById<TEvent>(Guid commitId) where TEvent : IMessage;
        bool IsHandled(Guid commitId);
        void Save(IMessage @event);
    }
}