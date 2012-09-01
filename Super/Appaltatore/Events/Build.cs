

using Super.Appaltatore.Events.Builders;

namespace Super.Appaltatore.Events
{
    public static class BuildEvt
    {
        public static InterventoAmbProgrammatoBuilder InterventoAmbProgrammato { get { return new InterventoAmbProgrammatoBuilder(); } }

        public static InterventoConsuntivatoAmbNonResoBuilder InterventoConsuntivatoAmbNonReso { get { return new InterventoConsuntivatoAmbNonResoBuilder(); } }

        public static InterventoConsuntivatoAmbNonResoTrenitaliaBuilder InterventoConsuntivatoAmbNonResoTrenitalia { get { return new InterventoConsuntivatoAmbNonResoTrenitaliaBuilder(); } }

        public static InterventoConsuntivatoAmbResoBuilder InterventoConsuntivatoAmbReso { get { return new InterventoConsuntivatoAmbResoBuilder(); } }

        public static InterventoConsuntivatoRotManNonResoBuilder InterventoConsuntivatoRotManNonReso { get { return new InterventoConsuntivatoRotManNonResoBuilder(); } }

        public static InterventoConsuntivatoRotManNonResoTrenitaliaBuilder InterventoConsuntivatoRotManNonResoTrenitalia { get { return new InterventoConsuntivatoRotManNonResoTrenitaliaBuilder(); } }

        public static InterventoConsuntivatoRotManResoBuilder InterventoConsuntivatoRotManReso { get { return new InterventoConsuntivatoRotManResoBuilder(); } }

        public static InterventoConsuntivatoRotNonResoBuilder InterventoConsuntivatoRotNonReso { get { return new InterventoConsuntivatoRotNonResoBuilder(); } }

        public static InterventoConsuntivatoRotNonResoTrenitaliaBuilder InterventoConsuntivatoRotNonResoTrenitalia { get { return new InterventoConsuntivatoRotNonResoTrenitaliaBuilder(); } }

        public static InterventoConsuntivatoRotResoBuilder InterventoConsuntivatoRotReso { get { return new InterventoConsuntivatoRotResoBuilder(); } }

        public static InterventoRotManProgrammatoBuilder InterventoRotManProgrammato { get { return new InterventoRotManProgrammatoBuilder(); } }

        public static InterventoRotProgrammatoBuilder InterventoRotProgrammato { get { return new InterventoRotProgrammatoBuilder(); } }
        
    }
}