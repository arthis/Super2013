using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Super.Contabilita.Domain.Builders;

namespace Super.Contabilita.Domain
{
    public static class Build
    {
        public static BasePriceBuilder BasePrice { get { return new BasePriceBuilder();}}
    }
}
