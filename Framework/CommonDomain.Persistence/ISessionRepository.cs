using System;

namespace CommonDomain.Persistence
{
    public interface ISecurityUserRepository
    {
        ISecurityUser GetSecurityUser(Guid securityToken);
    }
}