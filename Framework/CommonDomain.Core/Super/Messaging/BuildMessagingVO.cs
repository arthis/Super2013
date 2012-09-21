using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Messaging
{
    public static class BuildMessagingVO
    {
        public static MsgIntervalBuilder MsgInterval { get { return new MsgIntervalBuilder(); } }
        public static MsgIntervalOpenedBuilder MsgIntervalOpened { get { return new MsgIntervalOpenedBuilder(); } }
        public static MsgOggettoRotManBuilder MsgOggettoRotMan { get { return new MsgOggettoRotManBuilder(); } }
        public static MsgOggettoRotBuilder MsgOggettoRot { get { return new MsgOggettoRotBuilder(); } }
        public static MsgWorkPeriodBuilder MsgWorkPeriod { get { return new MsgWorkPeriodBuilder(); } }
        public static MsgPeriodBuilder MsgPeriod { get { return new MsgPeriodBuilder(); } }
        public static MsgTrenoBuilder MsgTreno { get { return new MsgTrenoBuilder(); } }
        public static MsgRuleBuilder MsgRule { get { return new MsgRuleBuilder(); } }

        
    }
}
