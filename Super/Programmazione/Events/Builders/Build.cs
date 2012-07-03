

namespace Super.Programmazione.Events.Builders
{
    public static class Build
    {
        public static InterventoRotPianificatoBuilder InterventoRotPianificato { get { return new InterventoRotPianificatoBuilder(); } }

        public static InterventoRotManPianificatoBuilder InterventoRotManPianificato { get { return new InterventoRotManPianificatoBuilder(); } }

        public static InterventoAmbPianificatoBuilder InterventoAmbPianificato { get { return new InterventoAmbPianificatoBuilder(); } }

        
    }
}