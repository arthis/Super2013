using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public class Session :ISession
    {
        private Guid _userId;

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public Session(Guid userId)
        {
            Contract.Requires(userId!=Guid.Empty);

            UserId = userId;
        }

        
    }
}
