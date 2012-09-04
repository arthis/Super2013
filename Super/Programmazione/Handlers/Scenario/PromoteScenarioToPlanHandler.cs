using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;
using IEventRepository = CommonDomain.Persistence.IEventRepository;

namespace Super.Programmazione.Handlers.Scenario
{
    public class PromoteScenarioToPlanHandler : CommandHandler<PromoteScenarioToPlan>
    {
        public PromoteScenarioToPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(PromoteScenarioToPlan cmd)
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
    }
}
