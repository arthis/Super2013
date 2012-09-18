using Super.Programmazione.Commands.Builders;
using Super.Programmazione.Commands.Builders.Intervento;
using Super.Programmazione.Commands.Builders.InterventoGeneration;
using Super.Programmazione.Commands.Builders.Plan;
using Super.Programmazione.Commands.Builders.Scenario;
using Super.Programmazione.Commands.Builders.Schedulazione;
using Super.Programmazione.Commands.Builders.System;

namespace Super.Programmazione.Commands
{
    public static class BuildCmd
    {
        public static PromoteScenarioToPlanBuilder PromoteScenarioToPlan { get { return new PromoteScenarioToPlanBuilder(); } }

        public static CreateScenarioBuilder CreateScenario { get { return new CreateScenarioBuilder(); } }

        public static ChangeDescriptionScenarioBuilder ChangeDescriptionScenario { get { return new ChangeDescriptionScenarioBuilder(); } }

        public static CancelScenarioBuilder CancelScenario { get { return new CancelScenarioBuilder(); } }

        public static AddSchedulazioneRotToScenarioBuilder AddSchedulazioneRotToScenario { get { return new AddSchedulazioneRotToScenarioBuilder(); } }

        public static AddSchedulazioneRotManToScenarioBuilder AddSchedulazioneRotManToScenario { get { return new AddSchedulazioneRotManToScenarioBuilder(); } }

        public static AddSchedulazioneAmbToScenarioBuilder AddSchedulazioneAmbToScenario { get { return new AddSchedulazioneAmbToScenarioBuilder(); } }

        public static UpdateSchedulazioneRotOfScenarioBuilder UpdateSchedulazioneRotOfScenario { get { return new UpdateSchedulazioneRotOfScenarioBuilder(); } }

        public static UpdateSchedulazioneRotManOfScenarioBuilder UpdateSchedulazioneRotManOfScenario { get { return new UpdateSchedulazioneRotManOfScenarioBuilder(); } }

        public static UpdateSchedulazioneAmbOfScenarioBuilder UpdateSchedulazioneAmbOfScenario { get { return new UpdateSchedulazioneAmbOfScenarioBuilder(); } }

        public static CancelSchedulazioneFromScenarioBuilder CancelSchedulazioneFromScenario { get { return new CancelSchedulazioneFromScenarioBuilder(); } }

        public static AddSchedulazioneRotToPlanBuilder AddSchedulazioneRotToPlan { get { return new AddSchedulazioneRotToPlanBuilder(); } }

        public static AddSchedulazioneRotManToPlanBuilder AddSchedulazioneRotManToPlan { get { return new AddSchedulazioneRotManToPlanBuilder(); } }

        public static AddSchedulazioneAmbToPlanBuilder AddSchedulazioneAmbToPlan { get { return new AddSchedulazioneAmbToPlanBuilder(); } }

        public static UpdateSchedulazioneRotOfPlanBuilder UpdateSchedulazioneRotOfPlan { get { return new UpdateSchedulazioneRotOfPlanBuilder(); } }

        public static UpdateSchedulazioneRotManOfPlanBuilder UpdateSchedulazioneRotManOfPlan { get { return new UpdateSchedulazioneRotManOfPlanBuilder(); } }

        public static UpdateSchedulazioneAmbOfPlanBuilder UpdateSchedulazioneAmbOfPlan { get { return new UpdateSchedulazioneAmbOfPlanBuilder(); } }

        public static CancelSchedulazioneFromPlanBuilder CancelSchedulazioneFromPlan { get { return new CancelSchedulazioneFromPlanBuilder(); } }


        public static AddRuleToSchedulazioneRotBuilder AddRuleToSchedulazioneRot { get { return new AddRuleToSchedulazioneRotBuilder(); } }

        public static AddRuleToSchedulazioneRotManBuilder AddRuleToSchedulazioneRotMan { get { return new AddRuleToSchedulazioneRotManBuilder(); } }

        public static AddRuleToSchedulazioneAmbBuilder AddRuleToSchedulazioneAmb { get { return new AddRuleToSchedulazioneAmbBuilder(); } }

        public static RemoveRuleFromSchedulazioneBuilder RemoveRuleFromSchedulazione { get { return new RemoveRuleFromSchedulazioneBuilder(); } }

        public static AskToGenerateInterventiBuilder AskToGenerateInterventi { get { return new AskToGenerateInterventiBuilder(); } }
        
        public static ConfirmGenerationSucceedBuilder ConfirmGenerationSucceed { get { return new ConfirmGenerationSucceedBuilder(); } }

        public static ConfirmGenerationFailedBuilder ConfirmGenerationFailed { get { return new ConfirmGenerationFailedBuilder(); } }

        

        public static AddInterventoRotToPlanBuilder AddInterventoRotToPlan { get { return new AddInterventoRotToPlanBuilder(); } }

        public static AddInterventoRotManToPlanBuilder AddInterventoRotManToPlan { get { return new AddInterventoRotManToPlanBuilder(); } }
        
        public static AddInterventoAmbToPlanBuilder AddInterventoAmbToPlan { get { return new AddInterventoAmbToPlanBuilder(); } }

        public static UpdateInterventoRotOfPlanBuilder UpdateInterventoRotOfPlan { get { return new UpdateInterventoRotOfPlanBuilder(); } }

        public static UpdateInterventoRotManOfPlanBuilder UpdateInterventoRotManOfPlan { get { return new UpdateInterventoRotManOfPlanBuilder(); } }

        public static UpdateInterventoAmbOfPlanBuilder UpdateInterventoAmbOfPlan { get { return new UpdateInterventoAmbOfPlanBuilder(); } }

        public static CancelInterventoFromPlanBuilder CancelInterventoFromPlan { get { return new CancelInterventoFromPlanBuilder(); } }

        public static GenerateInterventoRotForSchedulazioneBuilder GenerateInterventoRotForSchedulazione { get { return new GenerateInterventoRotForSchedulazioneBuilder();}}

        public static GenerateInterventoRotManForSchedulazioneBuilder GenerateInterventoRotManForSchedulazione { get { return new GenerateInterventoRotManForSchedulazioneBuilder(); } }

        public static GenerateInterventoAmbForSchedulazioneBuilder GenerateInterventoAmbForSchedulazione { get { return new GenerateInterventoAmbForSchedulazioneBuilder(); } }

        #region system


        public static AddUserToSystemBuilder AddUserToSystem { get { return new AddUserToSystemBuilder(); } }


        #endregion

        #region Intervento Generation

        public static StartGenerationOfInterventiBuilder StartGenerationOfInterventi {get {return new StartGenerationOfInterventiBuilder();}}
        #endregion

        #region Plan

        public static CancelPlanBuilder CancelPlan { get { return new CancelPlanBuilder(); } }

        public static CreatePlanFromPromotedScenarioBuilder CreatePlanFromPromotedScenario { get { return new CreatePlanFromPromotedScenarioBuilder(); } }

        #endregion

        #region Schedulazione

        public static CalculateSchedulazionePriceBuilder CalculateSchedulazionePrice { get { return new CalculateSchedulazionePriceBuilder(); } }
       
        #endregion

    }

   
}