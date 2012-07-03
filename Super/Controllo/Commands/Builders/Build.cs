namespace Super.Controllo.Commands.Builders
{
    public static class Build
    {
        public static CloseInterventoBuilder CloseIntervento { get { return new CloseInterventoBuilder(); } }

        public static ControlInterventoAmbResoBuilder ControlInterventoAmbReso { get { return new ControlInterventoAmbResoBuilder(); } }

        public static ControlInterventoNonResoBuilder ControlInterventoNonReso { get { return new ControlInterventoNonResoBuilder(); } }

        public static ControlInterventoRotManResoBuilder ControlInterventoRotManReso { get { return new ControlInterventoRotManResoBuilder(); } }

        public static ControlInterventoRotResoBuilder ControlInterventoRotReso { get { return new ControlInterventoRotResoBuilder(); } }

        public static ReopenInterventoBuilder ReopenIntervento { get { return new ReopenInterventoBuilder(); } }

        public static AllowControlInterventoBuilder AllowControlIntervento { get { return new AllowControlInterventoBuilder(); } }

        

    }
}