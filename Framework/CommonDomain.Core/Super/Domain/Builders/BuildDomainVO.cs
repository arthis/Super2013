using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public static class BuildDomainVO
    {
        public static IntervalBuilder Interval { get { return new IntervalBuilder(); } }
        public static IntervalOpenedBuilder IntervalOpened { get { return new IntervalOpenedBuilder(); } }
        public static OggettoRotManBuilder OggettoRotMan { get { return new OggettoRotManBuilder(); } }
        public static OggettoRotBuilder OggettoRot { get { return new OggettoRotBuilder(); } }
        public static PeriodBuilder Period { get { return new PeriodBuilder(); } }
        public static WorkPeriodBuilder WorkPeriod { get { return new WorkPeriodBuilder(); } }

        
    }
}
