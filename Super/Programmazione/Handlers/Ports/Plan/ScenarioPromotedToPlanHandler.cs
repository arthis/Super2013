using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Handlers.Ports.Plan
{
    public class ScenarioPromotedToPlanHandler : IPortHandler<ScenarioPromotedToPlan, CreatePlanFromPromotedScenario>
    {
        public CreatePlanFromPromotedScenario Port(ScenarioPromotedToPlan evt)
        {
            return BuildCmd.CreatePlanFromPromotedScenario
                .FromScenario(evt.Id)
                .Build(evt.Id, evt.CommitId, 1);
        }
    }
}
