namespace Super.Programmazione.Commands.Builders
{
    public static class Build
    {
        public static PromoteScenarioToPlanBuilder PromoteScenarioToPlan { get { return new PromoteScenarioToPlanBuilder(); } }

        public static CreateScenarioBuilder CreateScenario { get { return new CreateScenarioBuilder(); } }

        public static UpdateScenarioBuilder UpdateScenario { get { return new UpdateScenarioBuilder(); } }

        public static DeleteScenarioBuilder DeleteScenario { get { return new DeleteScenarioBuilder(); } }

        public static AddSchedulationToScenarioBuilder AddSchedulationToScenario { get { return new AddSchedulationToScenarioBuilder(); } }

        public static UpdateSchedulationOfScenarioBuilder UpdateSchedulationOfScenario { get { return new UpdateSchedulationOfScenarioBuilder(); } }

        public static CancelSchedulationOfScenarioBuilder CancelSchedulationOfScenario { get { return new CancelSchedulationOfScenarioBuilder(); } }

        public static AddSchedulationToPlanBuilder AddSchedulationToPlan { get { return new AddSchedulationToPlanBuilder(); } }

        public static UpdateSchedulationOfPlanBuilder UpdateSchedulationOfPlan { get { return new UpdateSchedulationOfPlanBuilder(); } }

        public static CancelSchedulationOfPlanBuilder CancelSchedulationOfPlan { get { return new CancelSchedulationOfPlanBuilder(); } }

        public static AddRuleToSchedulazioneBuilder AddRuleToSchedulazione { get { return new AddRuleToSchedulazioneBuilder(); } }

        public static RemoveRuleToSchedulazioneBuilder RemoveRuleToSchedulazione { get { return new RemoveRuleToSchedulazioneBuilder(); } }

        public static GenerateInterventiBuilder GenerateInterventi { get { return new GenerateInterventiBuilder(); } }

        public static CreateInterventoBuilder CreateIntervento { get { return new CreateInterventoBuilder(); } }

        public static UpdateInterventoBuilder UpdateIntervento { get { return new UpdateInterventoBuilder(); } }

        public static DeleteInterventoBuilder DeleteIntervento { get { return new DeleteInterventoBuilder(); } }
               
    }
}