﻿using System.Collections.Generic;
using CommonDomain.Core.Super.Domain.Builders;
using System.Linq;

namespace CommonDomain.Core.Super.Domain
{
    public static class BuildDomainVO
    {
        public static IntervalBuilder Interval { get { return new IntervalBuilder(); } }
        public static IntervalOpenedBuilder IntervalOpened { get { return new IntervalOpenedBuilder(); } }
        public static OggettoRotManBuilder OggettoRotMan { get { return new OggettoRotManBuilder(); } }
        public static OggettoRotBuilder OggettoRot { get { return new OggettoRotBuilder(); } }
        public static PeriodBuilder Period { get { return new PeriodBuilder(); } }
        public static WorkPeriodBuilder WorkPeriod { get { return new WorkPeriodBuilder(); } }
        public static TrenoBuilder Treno { get { return new TrenoBuilder(); } }
        public static RuleBuilder Rule { get { return new RuleBuilder(); } }
        
        
    }


    
}
