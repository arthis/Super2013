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
    public class DeleteScenarioHandler: CommandHandler<DeleteScenario>
    {
        public DeleteScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(DeleteScenario cmd)
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
