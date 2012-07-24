

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

        public static RuleAddedToSchedulazioneRotBuilder RuleAddedToSchedulazioneRot { get { return new RuleAddedToSchedulazioneRotBuilder(); } }

        public static RuleAddedToSchedulazioneRotManBuilder RuleAddedToSchedulazioneRotMan { get { return new RuleAddedToSchedulazioneRotManBuilder(); } }

        public static RuleAddedToSchedulazioneAmbBuilder RuleAddedToSchedulazioneAmb { get { return new RuleAddedToSchedulazioneAmbBuilder(); } }

        public static SchedulationRotAddedToScenarioBuilder SchedulationRotAddedToScenario { get { return new SchedulationRotAddedToScenarioBuilder(); } }

        public static SchedulationRotManAddedToScenarioBuilder SchedulationRotManAddedToScenario { get { return new SchedulationRotManAddedToScenarioBuilder(); } }

        public static SchedulationAmbAddedToScenarioBuilder SchedulationAmbAddedToScenario { get { return new SchedulationAmbAddedToScenarioBuilder(); } }

        public static InterventoCancelledFromPlanBuilder InterventoCancelledFromPlan { get { return new InterventoCancelledFromPlanBuilder(); } }

        public static PlanCancelledBuilder PlanCancelled { get { return new PlanCancelledBuilder(); } }

        public static SchedulationCancelledFromPlanBuilder SchedulationCancelledFromPlan { get { return new SchedulationCancelledFromPlanBuilder(); } }

        public static SchedulationCancelledFromScenarioBuilder SchedulationCancelledFromScenario { get { return new SchedulationCancelledFromScenarioBuilder(); } }

        public static ScenarioCreatedBuilder ScenarioCreated { get { return new ScenarioCreatedBuilder(); } }

        public static ScenarioDeletedBuilder ScenarioDeleted { get { return new ScenarioDeletedBuilder(); } }

        public static ScenarioPromotedToPlanBuilder ScenarioPromotedToPlanBuilder { get { return new ScenarioPromotedToPlanBuilder(); } }

        public static RuleRemovedFromSchedulazioneBuilder RuleRemovedFromSchedulazione { get { return new RuleRemovedFromSchedulazioneBuilder(); } }

        public static InterventoRotUpdatedOfPlanBuilder InterventoRotUpdatedOfPlan { get { return new InterventoRotUpdatedOfPlanBuilder(); } }

        public static InterventoRotManUpdatedOfPlanBuilder InterventoRotManUpdatedOfPlan { get { return new InterventoRotManUpdatedOfPlanBuilder(); } }

        public static InterventoAmbUpdatedOfPlanBuilder InterventoAmbUpdatedOfPlan { get { return new InterventoAmbUpdatedOfPlanBuilder(); } }

        public static SchedulationRotUpdatedOfScenarioBuilder SchedulationRotUpdatedOfScenario { get { return new SchedulationRotUpdatedOfScenarioBuilder(); } }

        public static SchedulationRotManUpdatedOfScenarioBuilder SchedulationRotManUpdatedOfScenario { get { return new SchedulationRotManUpdatedOfScenarioBuilder(); } }

        public static SchedulationAmbUpdatedOfScenarioBuilder SchedulationAmbUpdatedOfScenario { get { return new SchedulationAmbUpdatedOfScenarioBuilder(); } }
        
        



        


        
    }
}