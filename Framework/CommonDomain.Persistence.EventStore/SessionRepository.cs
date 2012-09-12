using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace CommonDomain.Persistence.EventStore
{
    public class SessionRepository :ISessionRepository
    {
        public ISession GetSession(Guid securityToken)
        {
            return  new Session(Guid.NewGuid(),true);
        }
    }
}
