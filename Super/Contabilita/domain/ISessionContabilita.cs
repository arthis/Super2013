using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;

namespace Super.Contabilita.Domain
{
    public interface ISessionContabilita : ISession
    {
        Domain.Pricing.Pricing Pricing { get; }
    }

   
}
