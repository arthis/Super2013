

namespace Super.Programmazione.Events.Builders
{
    public static class Build
    {
        public static InterventoRotGeneratedBuilder InterventoRotGenerated { get { return new InterventoRotGeneratedBuilder(); } }

        public static InterventoRotManGeneratedBuilder InterventoRotManGenerated { get { return new InterventoRotManGeneratedBuilder(); } }

        public static InterventoAmbGeneratedBuilder InterventoAmbGenerated { get { return new InterventoAmbGeneratedBuilder(); } }

        public static InterventoRotAddedToPlanBuilder InterventoRotAddedToPlan { get { return new InterventoRotAddedToPlanBuilder(); } }

        public static InterventoRotManAddedToPlanBuilder InterventoRotManAddedToPlan { get { return new InterventoRotManAddedToPlanBuilder(); } }

        public static InterventoAmbAddedToPlanBuilder InterventoAmbAddedToPlan { get { return new InterventoAmbAddedToPlanBuilder(); } }

        public static SchedulationRotAddedToPlanBuilder SchedulationRotAddedToPlan { get { return new SchedulationRotAddedToPlanBuilder(); } }

        public static SchedulationRotManAddedToPlanBuilder SchedulationRotManAddedToPlan { get { return new SchedulationRotManAddedToPlanBuilder(); } }

        public static SchedulationAmbAddedToPlanBuilder SchedulationAmbAddedToPlan { get { return new SchedulationAmbAddedToPlanBuilder(); } }



        
    }
}