using System;

namespace CommonDomain.Persistence
{
    public interface ISecurityUserRepository
    {
        ISecurityUser GetUser(Guid securityToken);
    }
}