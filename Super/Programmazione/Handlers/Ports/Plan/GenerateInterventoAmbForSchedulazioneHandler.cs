using System;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Handlers.Commands.Intervento
{
    public class ScenarioPromotedToPlanHandler : IPortHandler<ScenarioPromotedToPlan>
    {
        

        public override CommandValidation Execute(GenerateInterventoAmbForSchedulazione cmd)
        {
            throw new NotImplementedException();

            //Contract.Requires<ArgumentNullException>(cmd != null);

        


            //var existingIntervento = EventRepository.GetById<Scenario>(cmd.Id);

            //if (!existingIntervento.IsNull())
            //    throw new AlreadyCreatedAggregateRootException();

            //existingIntervento.AllowControl(cmd.Id);

            //EventRepository.Save(existingIntervento, cmd.CommitId);

            //return existingIntervento.CommandValidationMessages; 
        }

        public void port(ScenarioPromotedToPlan evt)
        {
            var cmd = BuildCmd.CreatePlan
                .Build(evt.Id, evt.CommitId, 1);


        }
    }
}
