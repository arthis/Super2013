using Super.Programmazione.Events.Builders.Intervento;
using Super.Programmazione.Events.Builders.InterventoGeneration;
using Super.Programmazione.Events.Builders.Scenario;
using Super.Programmazione.Events.Builders.Schedulazione;
using Super.Programmazione.Events.Builders.System;

namespace Super.Programmazione.Events
{
    public static partial class BuildEvt
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


        #region Schedulazione


        #endregion

        public static InterventiAskedTobeGeneratedBuilder InterventiAskedTobeGenerated {get { return new InterventiAskedTobeGeneratedBuilder(); }
        }

      

        public static RuleAddedToSchedulazioneRotBuilder RuleAddedToSchedulazioneRot { get { return new RuleAddedToSchedulazioneRotBuilder(); } }

        public static RuleAddedToSchedulazioneRotManBuilder RuleAddedToSchedulazioneRotMan { get { return new RuleAddedToSchedulazioneRotManBuilder(); } }

        public static RuleAddedToSchedulazioneAmbBuilder RuleAddedToSchedulazioneAmb { get { return new RuleAddedToSchedulazioneAmbBuilder(); } }

        public static SchedulazioneRotAddedToScenarioBuilder SchedulazioneRotAddedToScenario { get { return new SchedulazioneRotAddedToScenarioBuilder(); } }

        public static SchedulazioneRotManAddedToScenarioBuilder SchedulazioneRotManAddedToScenario { get { return new SchedulazioneRotManAddedToScenarioBuilder(); } }

        public static SchedulazioneAmbAddedToScenarioBuilder SchedulazioneAmbAddedToScenario { get { return new SchedulazioneAmbAddedToScenarioBuilder(); } }

        public static InterventoCancelledFromPlanBuilder InterventoCancelledFromPlan { get { return new InterventoCancelledFromPlanBuilder(); } }

        

        
        public static SchedulazioneCancelledFromScenarioBuilder SchedulazioneCancelledFromScenario { get { return new SchedulazioneCancelledFromScenarioBuilder(); } }

        public static ScenarioCreatedBuilder ScenarioCreated { get { return new ScenarioCreatedBuilder(); } }

        public static DescriptionOfScenarioChangedBuilder DescriptionOfScenarioChanged { get { return new DescriptionOfScenarioChangedBuilder(); } }
        
        public static ScenarioCancelledBuilder ScenarioCancelled { get { return new ScenarioCancelledBuilder(); } }

        

        public static RuleRemovedFromSchedulazioneBuilder RuleRemovedFromSchedulazione { get { return new RuleRemovedFromSchedulazioneBuilder(); } }


        public static SchedulazioneRotUpdatedOfScenarioBuilder SchedulazioneRotUpdatedOfScenario { get { return new SchedulazioneRotUpdatedOfScenarioBuilder(); } }

        public static SchedulazioneRotManUpdatedOfScenarioBuilder SchedulazioneRotManUpdatedOfScenario { get { return new SchedulazioneRotManUpdatedOfScenarioBuilder(); } }

        public static SchedulazioneAmbUpdatedOfScenarioBuilder SchedulazioneAmbUpdatedOfScenario { get { return new SchedulazioneAmbUpdatedOfScenarioBuilder(); } }
        
    }
}