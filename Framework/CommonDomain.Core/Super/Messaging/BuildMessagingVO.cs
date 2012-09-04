using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Messaging
{
    public static class BuildMessagingVO
    {
        public static IntervalBuilder Interval { get { return new IntervalBuilder(); } }
        public static IntervalOpenedBuilder IntervalOpened { get { return new IntervalOpenedBuilder(); } }
        public static OggettoRotManBuilder OggettoRotMan { get { return new OggettoRotManBuilder(); } }
        public static OggettoRotBuilder OggettoRot { get { return new OggettoRotBuilder(); } }
        public static WorkPeriodBuilder WorkPeriod { get { return new WorkPeriodBuilder(); } }
        public static PeriodBuilder Period { get { return new PeriodBuilder(); } }
        public static TrenoBuilder Treno { get { return new TrenoBuilder(); } }

        
    }
}
