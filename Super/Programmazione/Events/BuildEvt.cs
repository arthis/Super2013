

using Super.Programmazione.Events.Builders;
using Super.Programmazione.Events.Builders.Intervento;
using Super.Programmazione.Events.Builders.Plan;
using Super.Programmazione.Events.Builders.Scenario;
using Super.Programmazione.Events.Builders.Schedulazione;

namespace Super.Programmazione.Events
{
    public static class BuildEvt
    {
        public static InterventoRotGeneratedBuilder InterventoRotGenerated { get { return new InterventoRotGeneratedBuilder(); } }

        public static InterventoRotManGeneratedBuilder InterventoRotManGenerated { get { return new InterventoRotManGeneratedBuilder(); } }

        public static InterventoAmbGeneratedBuilder InterventoAmbGenerated { get { return new InterventoAmbGeneratedBuilder(); } }

        public static InterventoRotAddedToPlanBuilder InterventoRotAddedToPlan { get { return new InterventoRotAddedToPlanBuilder(); } }

        public static InterventoRotManAddedToPlanBuilder InterventoRotManAddedToPlan { get { return new InterventoRotManAddedToPlanBuilder(); } }

        public static InterventoAmbAddedToPlanBuilder InterventoAmbAddedToPlan { get { return new InterventoAmbAddedToPlanBuilder(); } }

        public static SchedulazioneRotAddedToPlanBuilder SchedulazioneRotAddedToPlan { get { return new SchedulazioneRotAddedToPlanBuilder(); } }

        public static SchedulazioneRotManAddedToPlanBuilder SchedulazioneRotManAddedToPlan { get { return new SchedulazioneRotManAddedToPlanBuilder(); } }

        public static SchedulazioneAmbAddedToPlanBuilder SchedulazioneAmbAddedToPlan { get { return new SchedulazioneAmbAddedToPlanBuilder(); } }

        public static RuleAddedToSchedulazioneRotBuilder RuleAddedToSchedulazioneRot { get { return new RuleAddedToSchedulazioneRotBuilder(); } }

        public static RuleAddedToSchedulazioneRotManBuilder RuleAddedToSchedulazioneRotMan { get { return new RuleAddedToSchedulazioneRotManBuilder(); } }

        public static RuleAddedToSchedulazioneAmbBuilder RuleAddedToSchedulazioneAmb { get { return new RuleAddedToSchedulazioneAmbBuilder(); } }

        public static SchedulazioneRotAddedToScenarioBuilder SchedulazioneRotAddedToScenario { get { return new SchedulazioneRotAddedToScenarioBuilder(); } }

        public static SchedulazioneRotManAddedToScenarioBuilder SchedulazioneRotManAddedToScenario { get { return new SchedulazioneRotManAddedToScenarioBuilder(); } }

        public static SchedulazioneAmbAddedToScenarioBuilder SchedulazioneAmbAddedToScenario { get { return new SchedulazioneAmbAddedToScenarioBuilder(); } }

        public static InterventoCancelledFromPlanBuilder InterventoCancelledFromPlan { get { return new InterventoCancelledFromPlanBuilder(); } }

        public static PlanCancelledBuilder PlanCancelled { get { return new PlanCancelledBuilder(); } }

        public static SchedulazioneCancelledFromPlanBuilder SchedulazioneCancelledFromPlan { get { return new SchedulazioneCancelledFromPlanBuilder(); } }

        public static SchedulazioneCancelledFromScenarioBuilder SchedulazioneCancelledFromScenario { get { return new SchedulazioneCancelledFromScenarioBuilder(); } }

        public static ScenarioCreatedBuilder ScenarioCreated { get { return new ScenarioCreatedBuilder(); } }

        public static ScenarioUpdatedBuilder ScenarioUpdated { get { return new ScenarioUpdatedBuilder(); } }
        
        public static ScenarioDeletedBuilder ScenarioDeleted { get { return new ScenarioDeletedBuilder(); } }

        public static ScenarioPromotedToPlanBuilder ScenarioPromotedToPlan { get { return new ScenarioPromotedToPlanBuilder(); } }

        public static RuleRemovedFromSchedulazioneBuilder RuleRemovedFromSchedulazione { get { return new RuleRemovedFromSchedulazioneBuilder(); } }

        public static InterventoRotUpdatedOfPlanBuilder InterventoRotUpdatedOfPlan { get { return new InterventoRotUpdatedOfPlanBuilder(); } }

        public static InterventoRotManUpdatedOfPlanBuilder InterventoRotManUpdatedOfPlan { get { return new InterventoRotManUpdatedOfPlanBuilder(); } }

        public static InterventoAmbUpdatedOfPlanBuilder InterventoAmbUpdatedOfPlan { get { return new InterventoAmbUpdatedOfPlanBuilder(); } }

        public static SchedulazioneRotUpdatedOfScenarioBuilder SchedulazioneRotUpdatedOfScenario { get { return new SchedulazioneRotUpdatedOfScenarioBuilder(); } }

        public static SchedulazioneRotManUpdatedOfScenarioBuilder SchedulazioneRotManUpdatedOfScenario { get { return new SchedulazioneRotManUpdatedOfScenarioBuilder(); } }

        public static SchedulazioneAmbUpdatedOfScenarioBuilder SchedulazioneAmbUpdatedOfScenario { get { return new SchedulazioneAmbUpdatedOfScenarioBuilder(); } }
        
        



        


        
    }
}