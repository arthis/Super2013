using CommonDomain.Core.Handlers;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Programma;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Handlers.Ports.Programma
{
    public class ScenarioCreatedHandler : IPortHandler<ScenarioCreated, CreateProgramma>
    {
        public CreateProgramma Port(ScenarioCreated evt)
        {
            return BuildCmd.CreateProgramma
                .Build(evt.IdProgramma,0);
        }
    }
}
