using System;

namespace CommonDomain.Persistence
{
    public interface ISessionRepository<out T> where T: ISession
    {
        T GetSession(Guid securityToken);
    }
}