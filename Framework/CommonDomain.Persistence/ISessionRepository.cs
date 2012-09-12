using System;

namespace CommonDomain.Persistence
{
    public interface ISessionRepository
    {
        ISession GetSession(Guid securityToken);
    }
}