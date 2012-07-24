namespace Super.Programmazione.Commands.Builders
{
    public static class Build
    {
        public static PromoteScenarioToPlanBuilder PromoteScenarioToPlan { get { return new PromoteScenarioToPlanBuilder(); } }

        public static CreateScenarioBuilder CreateScenario { get { return new CreateScenarioBuilder(); } }

        public static UpdateScenarioBuilder UpdateScenario { get { return new UpdateScenarioBuilder(); } }

        public static DeleteScenarioBuilder DeleteScenario { get { return new DeleteScenarioBuilder(); } }

        public static AddSchedulationRotToScenarioBuilder AddSchedulationRotToScenario { get { return new AddSchedulationRotToScenarioBuilder(); } }

        public static AddSchedulationRotManToScenarioBuilder AddSchedulationRotManToScenario { get { return new AddSchedulationRotManToScenarioBuilder(); } }

        public static AddSchedulationAmbToScenarioBuilder AddSchedulationAmbToScenario { get { return new AddSchedulationAmbToScenarioBuilder(); } }

        public static UpdateSchedulationRotOfScenarioBuilder UpdateSchedulationRotOfScenario { get { return new UpdateSchedulationRotOfScenarioBuilder(); } }

        public static UpdateSchedulationRotManOfScenarioBuilder UpdateSchedulationRotManOfScenario { get { return new UpdateSchedulationRotManOfScenarioBuilder(); } }

        public static UpdateSchedulationAmbOfScenarioBuilder UpdateSchedulationAmbOfScenario { get { return new UpdateSchedulationAmbOfScenarioBuilder(); } }

        public static CancelSchedulationFromScenarioBuilder CancelSchedulationFromScenario { get { return new CancelSchedulationFromScenarioBuilder(); } }

        public static AddSchedulationRotToPlanBuilder AddSchedulationRotToPlan { get { return new AddSchedulationRotToPlanBuilder(); } }

        public static AddSchedulationRotManToPlanBuilder AddSchedulationRotManToPlan { get { return new AddSchedulationRotManToPlanBuilder(); } }

        public static AddSchedulationAmbToPlanBuilder AddSchedulationAmbToPlan { get { return new AddSchedulationAmbToPlanBuilder(); } }

        public static UpdateSchedulationRotOfPlanBuilder UpdateSchedulationRotOfPlan { get { return new UpdateSchedulationRotOfPlanBuilder(); } }

        public static UpdateSchedulationRotManOfPlanBuilder UpdateSchedulationRotManOfPlan { get { return new UpdateSchedulationRotManOfPlanBuilder(); } }

        public static UpdateSchedulationAmbOfPlanBuilder UpdateSchedulationAmbOfPlan { get { return new UpdateSchedulationAmbOfPlanBuilder(); } }

        public static CancelSchedulationFromPlanBuilder CancelSchedulationFromPlan { get { return new CancelSchedulationFromPlanBuilder(); } }


        public static AddRuleToSchedulazioneRotBuilder AddRuleToSchedulazioneRot { get { return new AddRuleToSchedulazioneRotBuilder(); } }

        public static AddRuleToSchedulazioneRotManBuilder AddRuleToSchedulazioneRotMan { get { return new AddRuleToSchedulazioneRotManBuilder(); } }

        public static AddRuleToSchedulazioneAmbBuilder AddRuleToSchedulazioneAmb { get { return new AddRuleToSchedulazioneAmbBuilder(); } }

        public static RemoveRuleFromSchedulazioneBuilder RemoveRuleFromSchedulazione { get { return new RemoveRuleFromSchedulazioneBuilder(); } }

        public static GenerateInterventiBuilder GenerateInterventi { get { return new GenerateInterventiBuilder(); } }

        public static CancelPlanBuilder CancelPlan { get { return new CancelPlanBuilder(); } }

        public static AddInterventoRotToPlanBuilder AddInterventoRotToPlan { get { return new AddInterventoRotToPlanBuilder(); } }

        public static AddInterventoRotManToPlanBuilder AddInterventoRotManToPlan { get { return new AddInterventoRotManToPlanBuilder(); } }
        
        public static AddInterventoAmbToPlanBuilder AddInterventoAmbToPlan { get { return new AddInterventoAmbToPlanBuilder(); } }

        public static UpdateInterventoRotOfPlanBuilder UpdateInterventoRotOfPlan { get { return new UpdateInterventoRotOfPlanBuilder(); } }

        public static UpdateInterventoRotManOfPlanBuilder UpdateInterventoRotManOfPlan { get { return new UpdateInterventoRotManOfPlanBuilder(); } }

        public static UpdateInterventoAmbOfPlanBuilder UpdateInterventoAmbOfPlan { get { return new UpdateInterventoAmbOfPlanBuilder(); } }

        public static CancelInterventoFromPlanBuilder CancelInterventoFromPlan { get { return new CancelInterventoFromPlanBuilder(); } }
               
    }
}