namespace Super.Controllo.Events.Builders
{
    public static class Build
    {
        public static InterventoAmbControlledResoBuilder InterventoAmbControlledReso { get { return new InterventoAmbControlledResoBuilder(); } }

        public static InterventoClosedBuilder InterventoClosed { get { return new InterventoClosedBuilder(); } }

        public static InterventoControlledNonResoBuilder InterventoControlledNonReso { get { return new InterventoControlledNonResoBuilder(); } }

        public static InterventoRotControlledResoBuilder InterventoRotControlledReso { get { return new InterventoRotControlledResoBuilder(); } }

        public static InterventoRotManControlledResoBuilder InterventoRotManControlledReso { get { return new InterventoRotManControlledResoBuilder(); } }

        public static InterventoReopenedBuilder InterventoReopened { get { return new InterventoReopenedBuilder(); } }

    }
}