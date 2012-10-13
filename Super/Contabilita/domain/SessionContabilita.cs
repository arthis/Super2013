using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Domain
{
    public class SessionContabilita : ISessionContabilita
    {
        private readonly ISession _session;
        private readonly Pricing.Pricing _pricing;


        public SessionContabilita(ISession session  , Pricing.Pricing pricing)
        {
            Contract.Requires(pricing != null);
            Contract.Requires(session != null);

            _session = session;
            _pricing = pricing;
            
        }

        public Guid UserId { get { return _session.UserId; } }
        public bool IsAuthenticated { get { return _session.IsAuthenticated; } }
        public Pricing.Pricing Pricing { get { return _pricing; } }
    }
}
