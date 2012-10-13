using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public class CommonSession : ISession
    {
        

        public CommonSession(Guid userId, bool isAuthenticated)
        {
            Contract.Requires(userId!=Guid.Empty);
            
            UserId = userId;
            IsAuthenticated = isAuthenticated;
        }


        public Guid UserId { get; private set; }
        public bool IsAuthenticated { get; private set; }
    }
}
