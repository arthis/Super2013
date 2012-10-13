using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace CommonDomain.Persistence.EventStore
{
    public class SessionRepository :ISessionRepository<CommonSession>
    {
        public CommonSession GetSession(Guid securityToken)
        {
            return  new CommonSession(Guid.NewGuid(),true);
        }
    }


}
