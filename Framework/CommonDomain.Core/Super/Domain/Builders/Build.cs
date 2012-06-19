using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public static class Build
    {
        public static RollonPeriodBuilder RollonPeriod { get { return new RollonPeriodBuilder(); } }
    }
}
