using Super.Programmazione.Events.Builders.Intervento;
using Super.Programmazione.Events.Builders.InterventoGeneration;
using Super.Programmazione.Events.Builders.Plan;
using Super.Programmazione.Events.Builders.Scenario;
using Super.Programmazione.Events.Builders.Schedulazione;
using Super.Programmazione.Events.Builders.System;

namespace Super.Programmazione.Events
{
    public static class BuildEvt
    {
        #region InterventoGeneration

        public static GenerationOfInterventiSucceededBuilder GenerationOfInterventiSucceeded { get { return new GenerationOfInterventiSucceededBuilder(); } }

        public static GenerationOfInterventiStartedBuilder GenerationOfInterventiStarted { get { return new GenerationOfInterventiStartedBuilder(); } }

        public static GenerationOfInterventiFailedConfirmedBuilder GenerationOfInterventiFailedConfirmed { get { return new GenerationOfInterventiFailedConfirmedBuilder(); } }

        public static InterventoGeneratedConfirmedBuilder InterventoGeneratedConfirmed { get { return new InterventoGeneratedConfirmedBuilder(); } }

        #endregion

        #region System
         
        public static UserAddedToSystemBuilder UserAddedToSystem {get {return new UserAddedToSystemBuilder();}}
          
        #endregion

        #region Plan

        public static PlanCreatedBuilder PlanCreated { get { return new PlanCreatedBuilder(); } }

        public static PlanCancelledBuilder PlanCancelled { get { return new PlanCancelledBuilder(); } }

        #endregion

        #region Scenario

        public static ScenarioPromotedToPlanBuilder ScenarioPromotedToPlan { get { return new ScenarioPromotedToPlanBuilder(); } }

        #endregion

        #region Schedulazione


        #endregion

        public static InterventiAskedTobeGeneratedBuilder InterventiAskedTobeGenerated {get { return new InterventiAskedTobeGeneratedBuilder(); }
        }

        public static InterventoRotGeneratedFromSchedulazioneBuilder InterventoRotGeneratedFromSchedulazione { get { return new InterventoRotGeneratedFromSchedulazioneBuilder(); } }

        public static InterventoRotManGeneratedFromSchedulazioneBuilder InterventoRotManGeneratedFromSchedulazione { get { return new InterventoRotManGeneratedFromSchedulazioneBuilder(); } }

        public static InterventoAmbGeneratedFromSchedulazioneBuilder InterventoAmbGeneratedFromSchedulazione { get { return new InterventoAmbGeneratedFromSchedulazioneBuilder(); } }

        public static InterventoRotScheduledBuilder InterventoRotScheduled { get { return new InterventoRotScheduledBuilder(); } }

        public static InterventoRotManScheduledBuilder InterventoRotManScheduled { get { return new InterventoRotManScheduledBuilder(); } }

        public static InterventoAmbScheduledBuilder InterventoAmbScheduled { get { return new InterventoAmbScheduledBuilder(); } }

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

        

        public static SchedulazioneCancelledFromPlanBuilder SchedulazioneCancelledFromPlan { get { return new SchedulazioneCancelledFromPlanBuilder(); } }

        public static SchedulazioneCancelledFromScenarioBuilder SchedulazioneCancelledFromScenario { get { return new SchedulazioneCancelledFromScenarioBuilder(); } }

        public static ScenarioCreatedBuilder ScenarioCreated { get { return new ScenarioCreatedBuilder(); } }

        public static DescriptionOfScenarioChangedBuilder DescriptionOfScenarioChanged { get { return new DescriptionOfScenarioChangedBuilder(); } }
        
        public static ScenarioCancelledBuilder ScenarioCancelled { get { return new ScenarioCancelledBuilder(); } }

        

        public static RuleRemovedFromSchedulazioneBuilder RuleRemovedFromSchedulazione { get { return new RuleRemovedFromSchedulazioneBuilder(); } }

        public static InterventoRotUpdatedOfPlanBuilder InterventoRotUpdatedOfPlan { get { return new InterventoRotUpdatedOfPlanBuilder(); } }

        public static InterventoRotManUpdatedOfPlanBuilder InterventoRotManUpdatedOfPlan { get { return new InterventoRotManUpdatedOfPlanBuilder(); } }

        public static InterventoAmbUpdatedOfPlanBuilder InterventoAmbUpdatedOfPlan { get { return new InterventoAmbUpdatedOfPlanBuilder(); } }

        public static SchedulazioneRotUpdatedOfScenarioBuilder SchedulazioneRotUpdatedOfScenario { get { return new SchedulazioneRotUpdatedOfScenarioBuilder(); } }

        public static SchedulazioneRotManUpdatedOfScenarioBuilder SchedulazioneRotManUpdatedOfScenario { get { return new SchedulazioneRotManUpdatedOfScenarioBuilder(); } }

        public static SchedulazioneAmbUpdatedOfScenarioBuilder SchedulazioneAmbUpdatedOfScenario { get { return new SchedulazioneAmbUpdatedOfScenarioBuilder(); } }
        
    }
}